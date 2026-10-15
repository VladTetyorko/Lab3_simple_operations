using Lab.Tests;
using Lab.Tests.Task1.NumberReverser;
using Lab.Tests.Task2.WordRemover;
using Lab.Tests.Task3.ShapeArea;
using Lab.Tests.Task4.TextMasker;

const int NoFailures = 0;
const int FailureExitCode = 1;
const int SuccessExitCode = 0;

TestRunner testRunner = new TestRunner();

testRunner.Run(typeof(NumberValidatorTests));
testRunner.Run(typeof(NumberReverseServiceTests));
testRunner.Run(typeof(WordCountValidatorTests));
testRunner.Run(typeof(IntegerReaderTests));
testRunner.Run(typeof(WordRemoveServiceTests));
testRunner.Run(typeof(DimensionValidatorTests));
testRunner.Run(typeof(DecimalReaderTests));
testRunner.Run(typeof(AreaFormatterTests));
testRunner.Run(typeof(ShapeAreaServiceTests));
testRunner.Run(typeof(TextMaskServiceTests));
testRunner.PrintSummary();

if (testRunner.FailureCount > NoFailures)
{
    return FailureExitCode;
}

return SuccessExitCode;
