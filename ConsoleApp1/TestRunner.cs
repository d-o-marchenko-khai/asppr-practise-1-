namespace ConsoleApp1;

static class TestRunner
{
    public static void RunAll()
    {
        RunCase("ВАРІАНТ: Z = X1 + X3 + X6 -> max (зі змішаною системою обмежень)", Variant());
        RunCase("ЗАДАЧА 1: Z = 10x1 - x2 - 42x3 - 52x4 -> max (мішані обмеження)", Task1());
        RunCase("ПРИКЛАД 1: Z = x1 + 2x2 - x3 - x4 -> max", Example1());
        RunCase("ПРИКЛАД 2: Z = -2x1 + 3x2 - 3x4 -> min", Example2());
    }

    private static void RunCase(string title, LpProblem p)
    {
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("  " + title);
        Console.WriteLine("========================================");
        LinearProgrammingSolver.Solve(p, new Protocol(), SolveMode.OptimalWithObjective);
    }

    private static LpProblem Variant() => new LpProblem
    {
        N = 6,
        C = new double[] { 1, 0, 1, 0, 0, 1 },
        Goal = ObjectiveGoal.Max,
        Constraints = new List<Constraint>
        {
            new Constraint { A = new double[] { 1, 1, 1, 1, 1, 3 }, Type = ConstraintType.Equal, B = 4 },
            new Constraint { A = new double[] { 1, -4, 0, 1, 10, -1 }, Type = ConstraintType.LessOrEqual, B = 5 },
            new Constraint { A = new double[] { 1, 3, 7, 1, 15, -1 }, Type = ConstraintType.LessOrEqual, B = 2 }
        }
    };

    private static LpProblem Task1() => new LpProblem
    {
        N = 4,
        C = new double[] { 10, -1, -42, -52 },
        Goal = ObjectiveGoal.Max,
        Constraints = new List<Constraint>
        {
            new Constraint { A = new double[] { -2, 1, 1, 3 }, Type = ConstraintType.Equal, B = 2 },
            new Constraint { A = new double[] { -3, 2, -3, 0 }, Type = ConstraintType.Equal, B = 7 },
            new Constraint { A = new double[] { -3, 1, 4, 1 }, Type = ConstraintType.LessOrEqual, B = 1 },
            new Constraint { A = new double[] { 3, -2, 2, -2 }, Type = ConstraintType.LessOrEqual, B = -9 }
        }
    };

    private static LpProblem Example1() => new LpProblem
    {
        N = 4,
        C = new double[] { 1, 2, -1, -1 },
        Goal = ObjectiveGoal.Max,
        Constraints = new List<Constraint>
        {
            new Constraint { A = new double[] { 1, 1, -1, -2 }, Type = ConstraintType.LessOrEqual, B = 6 },
            new Constraint { A = new double[] { 1, 1, 1, -1 }, Type = ConstraintType.GreaterOrEqual, B = 5 },
            new Constraint { A = new double[] { 2, -1, 3, 4 }, Type = ConstraintType.LessOrEqual, B = 10 }
        }
    };

    private static LpProblem Example2() => new LpProblem
    {
        N = 4,
        C = new double[] { -2, 3, 0, -3 },
        Goal = ObjectiveGoal.Min,
        Constraints = new List<Constraint>
        {
            new Constraint { A = new double[] { 1, 1, -1, -2 }, Type = ConstraintType.LessOrEqual, B = 6 },
            new Constraint { A = new double[] { 1, 1, 1, -1 }, Type = ConstraintType.GreaterOrEqual, B = 5 },
            new Constraint { A = new double[] { 2, -1, 3, 4 }, Type = ConstraintType.LessOrEqual, B = 10 }
        }
    };
}
