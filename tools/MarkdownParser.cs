using System.Text;
using System.Text.RegularExpressions;

const string localPath = @"C:\Users\user.local\";
const string thirdHeading = "###";
const string secondHeading = "##";
const string firstHeading = "#";
string mdPath = Path.Combine(localPath, "CodeProjects", "ITMO-IS-DB-4-SEM", "Exam", "exam.md");
string questionsDir = Path.Combine(localPath, "VSCodeProjects", "itmo-db-course", "docs", "src", "exam");

var lines = File.ReadLines(mdPath).ToList();

var secondHeadingIndexes = lines
    .Where(line => new Regex($"^{secondHeading} [1-9]+[0-9]?").IsMatch(line))
    .Select(line => lines.IndexOf(line))
    .ToList();

var titleBuilder = new StringBuilder();
titleBuilder.AppendLine($"# Билеты по БД 2022{Environment.NewLine}");

foreach (var currentQuestionIndex in secondHeadingIndexes)
{
    var questionNumberChars = lines[currentQuestionIndex]
        .Skip($"{secondHeading} ".Length)
        .TakeWhile(item => int.TryParse($"{item}", out _))
        .ToArray();

    var questionNumber = new string(questionNumberChars);

    AppendQuestionToTitle(titleBuilder, lines[currentQuestionIndex], questionNumber);

    var questionLines = CutQuestionLinesByQuestionIndex(lines, secondHeadingIndexes, currentQuestionIndex);
    var headingIndexes = GetHeadingIndexes(questionLines);

    DecrementHeadings(headingIndexes, questionLines);
    ReplaceTipsToVueForm(questionLines);

    Directory.CreateDirectory(questionsDir);

    var questionFilePath = Path.Combine(questionsDir, $"Question_{questionNumber}.md");
    File.Create(questionFilePath).Dispose();
    File.AppendAllLines(questionFilePath, questionLines);
}

File.WriteAllText(Path.Combine(questionsDir, "README.md"), titleBuilder.ToString());

void DecrementHeadings(List<int> headingIndexes, IList<string> text)
{
    foreach (var headingIndex in headingIndexes)
    {
        var headingText = text[headingIndex];
        var firstHeadingIndex = headingText.IndexOf($"{firstHeading}", StringComparison.Ordinal);
        var lastHeadingIndex = headingText.LastIndexOf($"{firstHeading}", StringComparison.Ordinal);
        var newHeading = new string(Enumerable.Repeat('#', lastHeadingIndex - firstHeadingIndex).ToArray());

        text[headingIndex] =
            headingText.Replace(headingText.Substring(firstHeadingIndex, lastHeadingIndex + 1), newHeading);
    }
}

void AppendQuestionToTitle(StringBuilder titleBuilder, string questionText, string questionNumber)
{
    titleBuilder.AppendLine(
        $"{thirdHeading} [{questionText.Replace($"{secondHeading} ", string.Empty)}](../exam/Question_{questionNumber}.md){Environment.NewLine}");
}

List<string> CutQuestionLinesByQuestionIndex(IList<string> allLines, IList<int> headingIndexes, int currentIndex)
{
    if (headingIndexes.IndexOf(currentIndex) != headingIndexes.Count - 1)
    {
        return allLines
            .Skip(currentIndex)
            .Take(headingIndexes[headingIndexes.IndexOf(currentIndex) + 1] - 2 - currentIndex)
            .ToList();
    }

    return allLines
        .Skip(currentIndex)
        .Take(lines.Count - currentIndex)
        .ToList();
}

List<int> GetHeadingIndexes(List<string> questionLines)
{
    return questionLines
        .Select(line => new Regex($"^{firstHeading}+").IsMatch(line) ? questionLines.IndexOf(line) : int.MaxValue)
        .Where(num => num != int.MaxValue)
        .ToList();
}

void ReplaceTipsToVueForm(List<string> questionLines)
{
    var tipIndexes = new List<int>();
    foreach (var questionLine in questionLines)
    {
        if (!(questionLine.Contains('>') && questionLine.Count(ch => ch.Equals('>')) == 1 &&
              ((questionLine.IndexOf('>') > 0 && questionLine.Take(questionLine.IndexOf('>')).All(ch => ch == ' ')) ||
               questionLine.IndexOf('>') == 0)))
            continue;

        tipIndexes.Add(questionLines.IndexOf(questionLine));
    }

    const string tipStart = ":::tip";
    const string tipEnd = ":::";
    foreach (var tipIndex in tipIndexes)
    {
        var indexOfTip = questionLines[tipIndex].IndexOf('>');
        var tipLine = questionLines[tipIndex]
            .Substring(indexOfTip + 2, questionLines[tipIndex].Length - indexOfTip - 2);

        var spaces = new string(Enumerable.Repeat(' ', indexOfTip).ToArray());
        var newTipLine =
            $"{spaces}{tipStart}{Environment.NewLine}{spaces}{tipLine}{Environment.NewLine}{spaces}{tipEnd}";
        questionLines[tipIndex] = newTipLine;
    }
}