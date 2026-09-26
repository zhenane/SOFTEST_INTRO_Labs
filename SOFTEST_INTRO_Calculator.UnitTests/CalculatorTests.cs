using SOFTEST_INTRO_Calculator;
using NUnit.Framework;
namespace SOFTEST_INTRO_Calculator.UnitTests;
public class CalculatorTests
{
private Calculator _calculator = null!;
[SetUp]
public void SetUp()
{
_calculator = new Calculator();
}
[Test]
public void Add_TwoPositiveNumbers_ReturnsSum()
{
// Arrange: the calculator is created in SetUp.
// Act
double result = _calculator.Add(10, 20);
// Assert
Assert.That(result, Is.EqualTo(30));
}
[TestCase(0, 0, 0)]
[TestCase(0, 5, 5)]
[TestCase(-3, 8, 5)]
[TestCase(0.1, 0.2, 0.3)]
public void Add_RepresentativeInputs_ReturnsSum(
double a, double b, double expected)
{
double result = _calculator.Add(a, b);
Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}

[TestCase(1, 11, 7)]
[TestCase(10, 11, 11)]
[TestCase(11, 11, 15)]
public void Add_BinaryDigitInputs_ConcatenatesBinaryDigits(
double a, double b, double expected)
{
double result = _calculator.Add(a, b);
Assert.That(result, Is.EqualTo(expected));
}

[TestCase(50, 70, 120)]
[TestCase(10, 20, 30)]
[TestCase(2, 11, 13)]
[TestCase(-1, 1, 0)]
[TestCase(0.1, 1, 1.1)]
public void Add_NonBinaryInputs_ReturnsOrdinarySum(
double a, double b, double expected)
{
double result = _calculator.Add(a, b);
Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}

[TestCase(1000, 4, 250)]
[TestCase(10, 1, 10)]
[TestCase(0.5, 2, 0.25)]
public void Mtbf_PositiveInputs_ReturnsOperatingTimePerFailure(
double operatingTime, int failureCount, double expected)
{
double result = _calculator.Mtbf(operatingTime, failureCount);
Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}

[TestCase(0, 4)]
[TestCase(-1, 4)]
[TestCase(1000, 0)]
[TestCase(1000, -1)]
public void Mtbf_NonPositiveInputs_ThrowsArgumentException(
double operatingTime, int failureCount)
{
Assert.That(() => _calculator.Mtbf(operatingTime, failureCount),
Throws.TypeOf<ArgumentException>());
}

[TestCase(90, 10, 0.9)]
[TestCase(200, 50, 0.8)]
[TestCase(100, 0, 1)]
[TestCase(0, 10, 0)]
public void Availability_ValidInputs_ReturnsRatioBetweenZeroAndOne(
double mtbf, double mttr, double expected)
{
double result = _calculator.Availability(mtbf, mttr);
Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}

[TestCase(-1, 10)]
[TestCase(10, -1)]
[TestCase(0, 0)]
public void Availability_InvalidInputs_ThrowsArgumentException(
double mtbf, double mttr)
{
Assert.That(() => _calculator.Availability(mtbf, mttr),
Throws.TypeOf<ArgumentException>());
}

[TestCase(10, 100, 0, 10)]
[TestCase(10, 100, 10, 3.6787944117)]
public void CurrentFailureIntensity_ValidInputs_ReturnsMusaIntensity(
double initialIntensity, double totalFailures, double executionTime, double expected)
{
double result = _calculator.CurrentFailureIntensity(initialIntensity, totalFailures, executionTime);
Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}

[TestCase(10, 100, 0, 0)]
[TestCase(10, 100, 10, 63.2120558829)]
public void ExpectedCumulativeFailures_ValidInputs_ReturnsMusaFailures(
double initialIntensity, double totalFailures, double executionTime, double expected)
{
double result = _calculator.ExpectedCumulativeFailures(initialIntensity, totalFailures, executionTime);
Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}

[TestCase(0, 100, 5)]
[TestCase(-1, 100, 5)]
[TestCase(10, 0, 5)]
[TestCase(10, -1, 5)]
[TestCase(10, 100, -0.001)]
public void CurrentFailureIntensity_InvalidParameters_ThrowsArgumentException(
double initialIntensity, double totalFailures, double executionTime)
{
Assert.That(() => _calculator.CurrentFailureIntensity(initialIntensity, totalFailures, executionTime),
Throws.TypeOf<ArgumentException>());
}

[TestCase(0, 100, 5)]
[TestCase(-1, 100, 5)]
[TestCase(10, 0, 5)]
[TestCase(10, -1, 5)]
[TestCase(10, 100, -0.001)]
public void ExpectedCumulativeFailures_InvalidParameters_ThrowsArgumentException(
double initialIntensity, double totalFailures, double executionTime)
{
Assert.That(() => _calculator.ExpectedCumulativeFailures(initialIntensity, totalFailures, executionTime),
Throws.TypeOf<ArgumentException>());
}

[TestCase(15, 0)]
[TestCase(0, 0)]
public void Divide_ZeroDivisor_ThrowsArgumentException(double a, double b)
{
Assert.That(() => _calculator.Divide(a, b),
Throws.TypeOf<ArgumentException>());
}

[Test]
public void Factorial_Zero_ReturnsOne()
{
long result = _calculator.Factorial(0);
Assert.That(result, Is.EqualTo(1L));
}

[TestCase(1, 0)]
public void Triangle_Returns_Zero(double a, double b)
{
Assert.That(() => _calculator.TriangleArea(a, b), 
Throws.TypeOf<ArgumentException>());
}

[TestCase(0)]
public void Circle_Returns_Zero(double a)
{
Assert.That(() => _calculator.CircleArea(a),
Throws.TypeOf<ArgumentException>());
}

[TestCase(5, 5, 120)]
[TestCase(5, 4, 120)]
[TestCase(5, 3, 60)]
[TestCase(5, 0, 1)]
[TestCase(0, 0, 1)]
[TestCase(6, 2, 30)] // discriminating example: A (nPr) and B (nCr) diverge here (30 vs 15)
public void UnknownFunctionA_ValidInputs_ReturnsPermutations(int n, int r, long expected)
{
long result = _calculator.UnknownFunctionA(n, r);
Assert.That(result, Is.EqualTo(expected));
}

[TestCase(-4, 5)]
[TestCase(4, 5)]
public void UnknownFunctionA_InvalidInputs_ThrowsArgumentOutOfRangeException(int n, int r)
{
Assert.That(() => _calculator.UnknownFunctionA(n, r),
Throws.TypeOf<ArgumentOutOfRangeException>());
}

[TestCase(5, 5, 1)]
[TestCase(5, 4, 5)]
[TestCase(5, 3, 10)]
[TestCase(5, 0, 1)]
[TestCase(0, 0, 1)]
[TestCase(6, 2, 15)] // discriminating example: A (nPr) and B (nCr) diverge here (30 vs 15)
public void UnknownFunctionB_ValidInputs_ReturnsCombinations(int n, int r, long expected)
{
long result = _calculator.UnknownFunctionB(n, r);
Assert.That(result, Is.EqualTo(expected));
}

[TestCase(-4, 5)]
[TestCase(4, 5)]
public void UnknownFunctionB_InvalidInputs_ThrowsArgumentOutOfRangeException(int n, int r)
{
Assert.That(() => _calculator.UnknownFunctionB(n, r),
Throws.TypeOf<ArgumentOutOfRangeException>());
}
}
