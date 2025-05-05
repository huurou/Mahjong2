try {
    Set-Location $PSScriptRoot

    # TestResultsディレクトリの確認と中身削除
    if (-not (Test-Path -Path ".\TestResults")) {
        New-Item -ItemType Directory -Path ".\TestResults" | Out-Null
    } else {
        Get-ChildItem -Path ".\TestResults" -Recurse -Force | Remove-Item -Recurse -Force
    }

    Write-Output "テストを実行し、コードカバレッジ情報を収集しています..."
    dotnet test --collect:"XPlat Code Coverage"

    # カバレッジファイルの取得
    $coverageFiles = Get-ChildItem -Path ".\TestResults" -Recurse -Include "coverage.cobertura.xml", "*.xml" | Sort-Object -Descending LastWriteTime
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

    # レポートファイル群をTestResults直下に移動
    $reportFiles = Get-ChildItem -Path $coverageDir -Include "*.xml", "*.html", "*.htm", "*.css", "*.js", "*.ico", "*.png", "*.svg" -Recurse -ErrorAction SilentlyContinue
    foreach ($file in $reportFiles) {
        Move-Item -Path $file.FullName -Destination ".\TestResults" -Force
    }
    # レポートファイル移動後、カバレッジディレクトリを削除
    if ($coverageDir -ne (Resolve-Path .\TestResults)) {
        Remove-Item -Path $coverageDir -Recurse -Force -ErrorAction SilentlyContinue
    }
    $reportPath = Join-Path -Path ".\TestResults" -ChildPath "index.html"

    # 絶対パスをfile://形式に変換
    $absoluteReportPath = Resolve-Path $reportPath | Select-Object -ExpandProperty Path
    $fileUrl = "file:///" + ($absoluteReportPath -replace '\\','/')

    # Google Chromeで明示的に開く
    Write-Output "レポートをブラウザで開いています..."
    $chromePath = "C:\Program Files\Google\Chrome\Application\chrome.exe"
    if (-not (Test-Path $chromePath)) {
        $chromePath = "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
    }
    if (-not (Test-Path $chromePath)) {
        $chromePath = "${env:ProgramFiles}\Google\Chrome\Application\chrome.exe"
    }
    if (-not (Test-Path $chromePath)) {
        $chromePath = "${env:ProgramFiles(x86)}\Google\Chrome\Application\chrome.exe"
    }
    if (-not (Test-Path $chromePath)) {
        $chromePath = "${env:LocalAppData}\Google\Chrome\Application\chrome.exe"
    }

    if (-not (Test-Path $reportPath)) {
        throw "生成されたレポートファイルが見つかりません: $reportPath"
    }

    if (Test-Path $chromePath) {
        Write-Output "Google Chromeでレポートを開いています..."
        & $chromePath $fileUrl
    } else {
        Write-Warning "Google Chromeが見つかりませんでした。デフォルトのブラウザで開きます。"
        Invoke-Item $reportPath
    }
    Write-Output "コードカバレッジレポートの生成が完了しました！"
}
catch {
    Write-Error "エラーが発生しました: $_"
    Write-Error "スタックトレース: $($_.ScriptStackTrace)"
    Pause
}