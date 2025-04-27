try {
    Set-Location $PSScriptRoot
    Write-Output "テストを実行し、コードカバレッジ情報を収集しています..."
    dotnet test --collect:"XPlat Code Coverage" 

    # TestResultsディレクトリの確認
    if (-not (Test-Path -Path ".\TestResults")) {
        throw "TestResultsディレクトリが見つかりません。テストが正常に実行されなかった可能性があります。"
    }

    # カバレッジファイルの取得
    $coverageFiles = Get-ChildItem -Path ".\TestResults" -Recurse -Include "*.xml" | Sort-Object -Descending LastWriteTime
    if ($coverageFiles.Count -eq 0) {
        throw "カバレッジファイルが見つかりません。テスト実行中に問題が発生した可能性があります。"
    }

    $coverageFile = $coverageFiles[0].FullName
    Write-Output "使用するカバレッジファイル: $coverageFile"

    $coverageDir = (Split-Path -Parent $coverageFile)
    Write-Output "レポート出力先ディレクトリ: $coverageDir"

    # reportgeneratorコマンドの実行確認
    try {
        Write-Output "HTMLレポートを生成しています..."
        reportgenerator -reports:$coverageFile -targetdir:$coverageDir -reporttypes:Html
    }
    catch {
        throw "reportgeneratorの実行中にエラーが発生しました。ReportGenerator(.NET Global Tool)がインストールされているか確認してください。`nインストールするには: dotnet tool install -g dotnet-reportgenerator-globaltool を実行してください"
    }

    # Google Chromeで明示的に開く
    Write-Output "レポートをブラウザで開いています..."
    $chromePath = "C:\Program Files\Google\Chrome\Application\chrome.exe"
    # Chrome以外の場所にインストールされている場合のフォールバック
    if (-not (Test-Path $chromePath)) {
        $chromePath = "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
    }
    # さらにフォールバック
    if (-not (Test-Path $chromePath)) {
        $chromePath = "${env:ProgramFiles}\Google\Chrome\Application\chrome.exe"
    }
    if (-not (Test-Path $chromePath)) {
        $chromePath = "${env:ProgramFiles(x86)}\Google\Chrome\Application\chrome.exe"
    }
    if (-not (Test-Path $chromePath)) {
        $chromePath = "${env:LocalAppData}\Google\Chrome\Application\chrome.exe"
    }

    $reportPath = Join-Path -Path $coverageDir -ChildPath "index.html"
    if (-not (Test-Path $reportPath)) {
        throw "生成されたレポートファイルが見つかりません: $reportPath"
    }

    if (Test-Path $chromePath) {
        Write-Output "Google Chromeでレポートを開いています..."
        & $chromePath $reportPath
    } else {
        Write-Warning "Google Chromeが見つかりませんでした。デフォルトのブラウザで開きます。"
        Invoke-Item $reportPath
    }
    Write-Output "コードカバレッジレポートの生成が完了しました！"
}
catch {
    Write-Error "エラーが発生しました: $_"
    Write-Error "スタックトレース: $($_.ScriptStackTrace)"
}
finally {
    Pause
}