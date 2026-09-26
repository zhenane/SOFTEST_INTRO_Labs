using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;
namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;
[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
    private readonly CalculatorContext _context;
    private readonly ReliabilityContext _reliability;
    public UsingCalculatorBasicReliabilitySteps(CalculatorContext context, ReliabilityContext reliability)
    {
        _context = context;
        _reliability = reliability;
    }

    [Given("the initial failure intensity is {double} failures per CPU hour")]
    public void GivenTheInitialFailureIntensityIs(double value)
        => _reliability.InitialFailureIntensity = value;

    [Given("the expected total failures are {double}")]
    public void GivenTheExpectedTotalFailuresAre(double value)
        => _reliability.TotalExpectedFailures = value;

    [Given("the execution time is {double} CPU hours")]
    public void GivenTheExecutionTimeIs(double value)
        => _reliability.ExecutionTime = value;

    [When("I calculate the current failure intensity")]
    public void WhenICalculateTheCurrentFailureIntensity()
    {
        Calculate(() => _context.Calculator.CurrentFailureIntensity(
            _reliability.InitialFailureIntensity, _reliability.TotalExpectedFailures, _reliability.ExecutionTime));
    }

    [When("I calculate the expected cumulative failures")]
    public void WhenICalculateTheExpectedCumulativeFailures()
    {
        Calculate(() => _context.Calculator.ExpectedCumulativeFailures(
            _reliability.InitialFailureIntensity, _reliability.TotalExpectedFailures, _reliability.ExecutionTime));
    }

    private void Calculate(Func<double> calculation)
    {
        _context.Result = null;
        _context.Error = null;
        try
        {
            _context.Result = calculation();
        }
        catch (ArgumentException error)
        {
            _context.Error = error;
        }
    }
}
