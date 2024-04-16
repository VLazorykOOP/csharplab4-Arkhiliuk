using System;

class Triangle
{
    private int a, b, c;
    private int color;

    public Triangle(int a, int b, int c, int color)
    {
        if (!IsValid(a, b, c)) throw new ArgumentException("Invalid sides for a triangle.");
        this.a = a;
        this.b = b;
        this.c = c;
        this.color = color;
    }

    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return a;
                case 1: return b;
                case 2: return c;
                case 3: return color;
                default: throw new IndexOutOfRangeException("Invalid index for Triangle.");
            }
        }
        set
        {
            switch (index)
            {
                case 0: a = value; break;
                case 1: b = value; break;
                case 2: c = value; break;
                case 3: color = value; break;
                default: throw new IndexOutOfRangeException("Invalid index for Triangle.");
            }
        }
    }

    public static Triangle operator ++(Triangle t) => new Triangle(t.a + 1, t.b + 1, t.c + 1, t.color);

    public static Triangle operator --(Triangle t) => new Triangle(t.a - 1, t.b - 1, t.c - 1, t.color);

    public static bool operator true(Triangle t) => IsValid(t.a, t.b, t.c);

    public static bool operator false(Triangle t) => !IsValid(t.a, t.b, t.c);

    public static Triangle operator *(Triangle t, int scalar) => new Triangle(t.a * scalar, t.b * scalar, t.c * scalar, t.color);

    public override string ToString() => $"{a},{b},{c},{color:X}";

    public static explicit operator Triangle(string s)
    {
        var parts = s.Split(',');
        if (parts.Length != 4) throw new FormatException("Invalid string format for Triangle.");
        return new Triangle(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), Convert.ToInt32(parts[3], 16));
    }

    private static bool IsValid(int a, int b, int c) => a + b > c && a + c > b && b + c > a;
}


class VectorUInt
{
    private uint[] UIntArray;
    private uint size;
    private int codeError;
    private static uint num_vec;

    public VectorUInt()
    {
        UIntArray = new uint[1];
        UIntArray[0] = 0;
        size = 1;
        codeError = 0;
        num_vec++;
    }

    public VectorUInt(uint size)
    {
        UIntArray = new uint[size];
        for (var i = 0; i < size; i++)
        {
            UIntArray[i] = 0;
        }

        this.size = size;
        num_vec++;
        codeError = 0;
    }

    public VectorUInt(uint size, uint num)
    {
        UIntArray = new uint[size];
        for (var i = 0; i < size; i++)
        {
            UIntArray[i] = num;
        }

        this.size = size;
        num_vec++;
        codeError = 0;
    }

    ~VectorUInt()
    {
        Console.WriteLine("Destructor");
    }

    public void inputArr()
    {
        for (var i = 0; i < size; i++)
        {
            uint.TryParse(Console.ReadLine(), out UIntArray[i]);
        }
    }

    public void printArr()
    {
        for (var i = 0; i < size; i++)
        {
            Console.Write($"{UIntArray[i]} ");
        }
        Console.WriteLine();
    }

    public void setArr(uint num)
    {
        for (var i = 0; i < size; i++)
        {
            UIntArray[i] = num;
        }
    }

    public uint getSize()
    {
        return size;
    }
    public uint this[uint index]
    {
        get
        {
            if (index > size)
            {
                codeError = -1;
                return 0;
            }
            return UIntArray[index];
        }
        set
        {
            if (index > size)
            {
                codeError = -1;
            }
            else
            {
                UIntArray[index] = value;
            }
        }
    }
    public static VectorUInt operator ++(VectorUInt vectorUInt)
    {
        for (var i = 0; i < vectorUInt.size; i++)
        {
            vectorUInt.UIntArray[i]++;
        }
        return vectorUInt;
    }

    public static VectorUInt operator --(VectorUInt vectorUInt)
    {
        for (var i = 0; i < vectorUInt.size; i++)
        {
            vectorUInt.UIntArray[i]--;
        }
        return vectorUInt;
    }
    public static bool operator true(VectorUInt vectorUInt)
    {
        if (vectorUInt.size != 0)
        {
            return true;
        }
        return false;
    }
    public static bool operator false(VectorUInt vectorUInt)
    {
        if (vectorUInt.size != 0)
        {
            return false;
        }
        return true;
    }
    public static VectorUInt operator +(VectorUInt vectorUInt, int num)
    {
        for (var i = 0; i < vectorUInt.size; i++)
        {
            vectorUInt.UIntArray[i] = Convert.ToUInt32(vectorUInt.UIntArray[i] + num);
        }
        return vectorUInt;
    }

    public static VectorUInt operator +(VectorUInt a, VectorUInt b)
    {
        uint lessSize = a.size < b.size ? a.size : b.size;
        for (var i = 0; i < lessSize; i++)
        {
            a.UIntArray[i] += b.UIntArray[i];
        }
        return a;
    }
    public static VectorUInt operator -(VectorUInt vectoruint, int num)
    {
        for (var i = 0; i < vectoruint.size; i++)
        {
            vectoruint.UIntArray[i] = Convert.ToUInt32(vectoruint.UIntArray[i] - num);
        }
        return vectoruint;
    }

    public static VectorUInt operator -(VectorUInt a, VectorUInt b)
    {
        uint lessSize = a.size < b.size ? a.size : b.size;
        for (var i = 0; i < lessSize; i++)
        {
            a.UIntArray[i] -= b.UIntArray[i];
        }
        return a;
    }
    public static VectorUInt operator *(VectorUInt vectoruint, int num)
    {
        for (var i = 0; i < vectoruint.size; i++)
        {
            vectoruint.UIntArray[i] = Convert.ToUInt32(vectoruint.UIntArray[i] * num);
        }
        return vectoruint;
    }

    public static VectorUInt operator *(VectorUInt a, VectorUInt b)
    {
        uint lessSize = a.size < b.size ? a.size : b.size;
        for (var i = 0; i < lessSize; i++)
        {
            a.UIntArray[i] *= b.UIntArray[i];
        }
        return a;
    }
    public static VectorUInt operator /(VectorUInt vectoruint, int num)
    {
        for (var i = 0; i < vectoruint.size; i++)
        {
            vectoruint.UIntArray[i] = Convert.ToUInt32(vectoruint.UIntArray[i] / num);
        }
        return vectoruint;
    }

    public static VectorUInt operator /(VectorUInt a, VectorUInt b)
    {
        uint lessSize = a.size < b.size ? a.size : b.size;
        for (var i = 0; i < lessSize; i++)
        {
            a.UIntArray[i] /= b.UIntArray[i];
        }
        return a;
    }

}

class MatrixUInt
{
    private uint[,] UIntArray;
    private uint n,m;
    private int codeError;
    private static uint num_m;

    public MatrixUInt()
    {
        UIntArray = new uint[1,1];
        UIntArray[0,0] = 0;
        n = 1;
        m = 1;
        codeError = 0;
        num_m++;
    }

    public MatrixUInt(uint n, uint m)
    {
        UIntArray = new uint[n, m];
        for (var i = 0; i < n; i++)
        {
            for (var c = 0; c < m; c++)
            {
                UIntArray[i, c] = 0;
            }
        }
        this.n = n;
        this.m = m;
        num_m++;
        codeError = 0;
    }

    public MatrixUInt(uint n, uint m, uint num)
    {
        UIntArray = new uint[n, m];
        for (var i = 0; i < n; i++)
        {
            for (var c = 0; c < m; c++)
            {
                UIntArray[i, c] = num;
            }
        }
        this.n = n;
        this.m = m;
        num_m++;
        codeError = 0;
    }

    ~MatrixUInt()
    {
        Console.WriteLine("Destructor");
    }

    public void inputMat()
    {
        for (var i = 0; i < n; i++)
        {
            for (var c = 0; c < m; c++)
            {
                uint.TryParse(Console.ReadLine(), out UIntArray[i,c]);
            }
        }
    }

    public void PrintMat()
    {
        for (var i = 0; i < n; i++)
        {
                for (var c = 0; c < m; c++)
                {
                    Console.Write($"{UIntArray[i,c]} ");
                }
                Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void SetMat(uint num)
    {
        for (var i = 0; i < n; i++)
        {
            for (var c = 0; c < m; c++)
            {
                UIntArray[i, c] = num;
            }
        }
    }

    public uint this[uint i, uint j]
    {
        get
        {
            if (i > n || j > m)
            {
                codeError = -1;
                return 0;
            }
            return UIntArray[i,j];
        }
        set
        {
            if (i > n || j > m)
            {
                codeError = -1;
            }
            else
            {
                UIntArray[i, j] = value;
            }
        }
    }

    public uint this[int index]
    {
        //rown = n, column = m
        get
        {
            if (index < n * m - 1)
            {

                return UIntArray[index / m, (int)(index % m)];
            }
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            if (index < n * m - 1)
            {
                UIntArray[index / m, (int)(index % m)] = value;
            }
            else
            {
                codeError = -1;
            }
        }
    }

    public static MatrixUInt operator++(MatrixUInt matrixUInt)
    {
        for (var i = 0; i < matrixUInt.n; i++)
        {
            for (var c = 0; c < matrixUInt.m; c++)
            {
                matrixUInt.UIntArray[i, c]++;
            }
        }

        return matrixUInt;
    }

    public static MatrixUInt operator--(MatrixUInt matrixUInt)
    {
        for (var i = 0; i < matrixUInt.n; i++)
        {
            for (var c = 0; c < matrixUInt.m; c++)
            {
                matrixUInt.UIntArray[i, c]--;
            }
        }
        return matrixUInt;
    }
    public static bool operator true(MatrixUInt matrixUInt)
    {
        if(matrixUInt.n != 0 && matrixUInt.m != 0)
        {
            return true;
        }
        return false;
    }
    public static bool operator false(MatrixUInt matrixUInt)
    {
        if(matrixUInt.n != 0 && matrixUInt.m != 0)
        {
            return false;
        }
        return true;
    }
    public static MatrixUInt operator+(MatrixUInt matrixUInt, int num)
    {
        for (var i = 0; i < matrixUInt.n; i++)
        {
            for (var c = 0; c < matrixUInt.m; c++)
            {
                matrixUInt.UIntArray[i, c] = Convert.ToUInt32(matrixUInt.UIntArray[i, c] + num);
            }
        }

        return matrixUInt;
    }

    public static MatrixUInt operator+(MatrixUInt a, MatrixUInt b)
    {
        uint lessSizeN = a.n < b.n ? a.n : b.n;
        uint lessSizeM = a.m < b.m ? a.m : b.m;
        for (var i = 0; i < lessSizeN; i++)
        {
            for (int c = 0; c < lessSizeM; c++)
            {
                a.UIntArray[i, c] += b.UIntArray[i, c];
            }
        }
        return a;
    }
    public static MatrixUInt operator-(MatrixUInt matrixUInt, int num)
    {
        for (var i = 0; i < matrixUInt.n; i++)
        {
            for (var c = 0; c < matrixUInt.m; c++)
            {
                matrixUInt.UIntArray[i, c] = Convert.ToUInt32(matrixUInt.UIntArray[i,c] - num);
            }
        }

        return matrixUInt;
    }

    public static MatrixUInt operator-(MatrixUInt a, MatrixUInt b)
    {
        uint lessSizeN = a.n < b.n ? a.n : b.n;
        uint lessSizeM = a.m < b.m ? a.m : b.m;
        for (var i = 0; i < lessSizeN; i++)
        {
            for (int c = 0; c < lessSizeM; c++)
            {
                a.UIntArray[i, c] -= b.UIntArray[i, c];
            }
        }
        return a;
    }
    public static MatrixUInt operator*(MatrixUInt matrixUint, int num)
    {
        for (var i = 0; i < matrixUint.n; i++)
        {
            for (var c = 0; c < matrixUint.m; c++)
            {
                matrixUint.UIntArray[i, c] = Convert.ToUInt32(matrixUint.UIntArray[i,c] * num);
            }
        }
        return matrixUint;
    }

    public static MatrixUInt operator*(MatrixUInt a, MatrixUInt b)
    {
        uint lessSizeN = a.n < b.n ? a.n : b.n;
        uint lessSizeM = a.m < b.m ? a.m : b.m;
        for (var i = 0; i < lessSizeN; i++)
        {
            for (int c = 0; c < lessSizeM; c++)
            {
                a.UIntArray[i, c] *= b.UIntArray[i, c];
            }
        }
        return a;
    }
    public static MatrixUInt operator/(MatrixUInt matrixUint, int num)
    {
        for (var i = 0; i < matrixUint.n; i++)
        {
            for (var c = 0; c < matrixUint.m; c++)
            {
                matrixUint.UIntArray[i, c] = Convert.ToUInt32(matrixUint.UIntArray[i, c] / num);
            }
        }

        return matrixUint;
    }

    public static MatrixUInt operator/(MatrixUInt a, MatrixUInt b)
    {
        uint lessSizeN = a.n < b.n ? a.n : b.n;
        uint lessSizeM = a.m < b.m ? a.m : b.m;
        for (var i = 0; i < lessSizeN; i++)
        {
            for (int c = 0; c < lessSizeM; c++)
            {
                a.UIntArray[i, c] /= b.UIntArray[i, c];
            }
        }
        return a;
    }
}

class Program
{
    static void Main()
    {
        var triangle = new Triangle(3, 4, 5, 0xFF0000);
        Console.WriteLine(triangle);

        triangle[0] = 6;
        Console.WriteLine($"Після зміни сторони a: {triangle}");

        triangle++;
        Console.WriteLine($"Після інкремента: {triangle}");
        triangle--;
        Console.WriteLine($"Після декремента: {triangle}");

        if (triangle) Console.WriteLine("Трикутник існує.");
        else Console.WriteLine("Трикутник не існує.");

        var scaledTriangle = triangle * 2;
        Console.WriteLine($"Після масштабування: {scaledTriangle}");

        string triangleStr = triangle.ToString();
        var newTriangle = (Triangle)triangleStr;
        Console.WriteLine($"Створений з рядка: {newTriangle}");

        Console.WriteLine($"Сторона a: {triangle[0]}, Сторона b: {triangle[1]}, Сторона c: {triangle[2]}, Колір: {triangle[3]}");
        try
        {
            Console.WriteLine($"Invalid index: {triangle[4]}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        var arrA = new VectorUInt();
        var arrB = new VectorUInt(5, 3);
        Console.WriteLine($"Index[1]: {arrB[1]}");
        Console.WriteLine("Array A: ");
        arrA.printArr();
        Console.WriteLine("Array B: ");
        arrB.printArr();
        arrA++;
        Console.WriteLine("A++: ");
        arrA.printArr();
        arrA--;
        Console.WriteLine("A--: ");
        arrA.printArr();
        Console.WriteLine(arrA ? "Array A exists" : "Array A does not exists");
        Console.WriteLine(arrB ? "Array B exists" : "Array B does not exists");
        Console.WriteLine("Array B: ");
        arrB.printArr();
        arrB = arrB * 2;
        Console.WriteLine("Array B * 2: ");
        arrB.printArr();

        var matA = new MatrixUInt();
        var matB = new MatrixUInt(3, 3, 1);
        Console.WriteLine($"Index[1]: {matB[1]}");
        Console.WriteLine("Matrix A: ");
        matA.PrintMat();
        Console.WriteLine("Matrix B: ");
        matB.PrintMat();
        matB++;
        Console.WriteLine("Matrix B++: ");
        matB.PrintMat();
        Console.WriteLine(matA ? "Matrix A exists" : "Matrix A does not exists");
        Console.WriteLine(matB ? "Matrix B exists" : "Matrix B does not exists");
        Console.WriteLine("Matrix B: ");
        matB.PrintMat();
        matB = matB * 2;
        Console.WriteLine("Matrix B * 2: ");
        matB.PrintMat();
    }
}
