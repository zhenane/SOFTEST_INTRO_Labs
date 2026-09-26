using System.Globalization;
namespace SOFTEST_INTRO_Calculator;
public class Calculator
{
    public double Add(double a, double b)
    {
        string first = a.ToString(CultureInfo.InvariantCulture);
        string second = b.ToString(CultureInfo.InvariantCulture);
        if (IsBinaryDigits(first) && IsBinaryDigits(second))
        {
            return Convert.ToInt64(first + second, 2);
        }
        return a + b;
    }

    private static bool IsBinaryDigits(string text) => text.All(c => c == '0' || c == '1');

    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;
    // Starter version: complete the zero-divisor rule in section 5.
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Division by zero is not allowed.");
        }
        return a / b;
    }

    public long Factorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("Factorial is not defined for negative numbers.");
        }
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public long UnknownFunctionA(int n, int r)
    {
        if (n < 0 || r < 0 || r > n || n > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(r), "Require 0 <= r <= n <= 20.");
        }
        return Factorial(n) / Factorial(n - r);
    }

    public long UnknownFunctionB(int n, int r)
    {
        if (n < 0 || r < 0 || r > n || n > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(r), "Require 0 <= r <= n <= 20.");
        }
        return Factorial(n) / (Factorial(r) * Factorial(n - r));
    }

    public double TriangleArea(double a, double b)
    {
        if (a < 1 || b < 1)
        {
            throw new ArgumentException("Base length and height must be non-negative and non-zero.");
        }
        return 0.5 * a * b;
    }

    public double CircleArea(double a)
    {
        if (a < 1)
        {
            throw new ArgumentException("Radius must be non-negative and non-zero.");
        }
        return Math.PI * a * a;
    }
    public double Mtbf(double operatingTime, int failureCount)
    {
        if (operatingTime <= 0 || failureCount <= 0)
        {
            throw new ArgumentException("Operating time and failure count must be positive.");
        }
        return operatingTime / failureCount;
    }

    public double Availability(double mtbf, double mttr)
    {
        if (mtbf < 0 || mttr < 0 || mtbf + mttr <= 0)
        {
            throw new ArgumentException("MTBF and MTTR cannot be negative and must not both be zero.");
        }
        return mtbf / (mtbf + mttr);
    }

    // Basic Musa model. Execution time (tau) is in CPU hours; failure intensity is failures per CPU hour.
    public double CurrentFailureIntensity(double initialIntensity, double totalFailures, double executionTime)
    {
        ValidateMusaParameters(initialIntensity, totalFailures, executionTime);
        return initialIntensity * Math.Exp(-initialIntensity * executionTime / totalFailures);
    }

    public double ExpectedCumulativeFailures(double initialIntensity, double totalFailures, double executionTime)
    {
        ValidateMusaParameters(initialIntensity, totalFailures, executionTime);
        return totalFailures * (1 - Math.Exp(-initialIntensity * executionTime / totalFailures));
    }

    private static void ValidateMusaParameters(double initialIntensity, double totalFailures, double executionTime)
    {
        if (initialIntensity <= 0 || totalFailures <= 0 || executionTime < 0)
        {
            throw new ArgumentException("Require initial intensity > 0, total failures > 0 and execution time >= 0.");
        }
    }

    public double DoOperation(double a, double b, string op)
    {
    return op switch
        {
        "a" => Add(a, b),
        "s" => Subtract(a, b),
        "m" => Multiply(a, b),
        "d" => Divide(a, b),
        "f" => Factorial((int)a),
        "t" => TriangleArea(a, b),
        "c" => CircleArea(a),
        _ => throw new ArgumentException("Unknown operation.")
        };
    }

    public double GenMagicNum(
    int choice, string path, IFileReader fileReader)
    {
        ArgumentNullException.ThrowIfNull(fileReader);
        if (choice < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(choice));
        }
            string[] magicStrings = fileReader.Read(path);
            if (choice >= magicStrings.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(choice));
        }
        double magicNumber = double.Parse(magicStrings[choice]);
        return 2 * Math.Abs(magicNumber);
    }
}