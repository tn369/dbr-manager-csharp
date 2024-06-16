#!/bin/bash

# テストプロジェクトを自動検出するためのディレクトリ（必要に応じて変更）
SEARCH_DIR="../"

# カバレッジ結果の出力ディレクトリ
COVERAGE_OUTPUT_DIR="../coverage"

# 出力ディレクトリを作成（既に存在する場合はクリア）
rm -rf $COVERAGE_OUTPUT_DIR
mkdir -p $COVERAGE_OUTPUT_DIR

# カバレッジ収集のためのフォーマット
COVERAGE_FORMAT="cobertura"

# テストプロジェクトの検出
TEST_PROJECT_PATHS=$(find $SEARCH_DIR -name "*.csproj" -print | grep -E "Test|Tests")

# 各テストプロジェクトのカバレッジ結果を収集
for TEST_PROJECT_PATH in $TEST_PROJECT_PATHS
do
    PROJECT_NAME=$(basename $TEST_PROJECT_PATH .csproj)
    dotnet test $TEST_PROJECT_PATH --collect:"XPlat Code Coverage" --results-directory $COVERAGE_OUTPUT_DIR/$PROJECT_NAME -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=$COVERAGE_FORMAT
done

# カバレッジ結果の結合
reportgenerator -reports:$COVERAGE_OUTPUT_DIR/**/*.xml -targetdir:$COVERAGE_OUTPUT_DIR/report

# カバレッジレポートのパス
REPORT_PATH="$COVERAGE_OUTPUT_DIR/report/index.html"

# カバレッジレポートをブラウザで表示
if command -v xdg-open > /dev/null; then
    xdg-open $REPORT_PATH
elif command -v open > /dev/null; then
    open $REPORT_PATH
elif command -v start > /dev/null; then
    start $REPORT_PATH
else
    echo "Please open the following URL in your browser:"
    echo "file://$REPORT_PATH"
fi
