using Padutronics.Cloning;
using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Mathematics.Matrices;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class Matrix3x2F : ICloneable<Matrix3x2F>
{
    private const int Columns = 2;
    private const int Rows = 3;

    private readonly double[,] values = new double[Rows, Columns];

    public Matrix3x2F() :
        this(new double[Rows, Columns])
    {
    }

    public Matrix3x2F(double[,] values)
    {
        int rows = values.GetLength(dimension: 0);
        if (rows != Rows)
        {
            throw new ArgumentException($"Matrix 3x2 cannot have {rows} rows.", nameof(values));
        }

        int columns = values.GetLength(dimension: 1);
        if (columns != Columns)
        {
            throw new ArgumentException($"Matrix 3x2 cannot have {columns} columns.", nameof(values));
        }

        this.values = values;
    }

    public static Matrix3x2F Identity { get; } = new Matrix3x2F(new double[,] { { 1.0, 0.0 }, { 0.0, 1.0 }, { 0.0, 0.0 } });

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"[({M11}, {M12}), ({M21}, {M22}), ({M31}, {M32})]";

    public double M11
    {
        get => values[0, 0];
        private set => values[0, 0] = value;
    }

    public double M12
    {
        get => values[0, 1];
        private set => values[0, 1] = value;
    }

    public double M21
    {
        get => values[1, 0];
        private set => values[1, 0] = value;
    }

    public double M22
    {
        get => values[1, 1];
        private set => values[1, 1] = value;
    }

    public double M31
    {
        get => values[2, 0];
        private set => values[2, 0] = value;
    }

    public double M32
    {
        get => values[2, 1];
        private set => values[2, 1] = value;
    }

    public Matrix3x2F Clone()
    {
        var valuesCopy = (double[,])values.Clone();

        return new Matrix3x2F(valuesCopy);
    }

    object ICloneable.Clone()
    {
        return Clone();
    }
}