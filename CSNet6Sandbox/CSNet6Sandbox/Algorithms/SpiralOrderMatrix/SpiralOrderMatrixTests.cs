using FluentAssertions;
using NUnit.Framework;
using static CSNet6Sandbox.Algorithms.SpiralOrderMatrix.Solution;

namespace CSNet6Sandbox.Algorithms.SpiralOrderMatrix;

/*
 SOURCE: https://www.interviewbit.com/problems/spiral-order-matrix-i/

Given a matrix of m * n elements (m rows, n columns), return all elements of the matrix in spiral order.

Example:

Given the following matrix:

[
    [ 1, 2, 3 ],
    [ 4, 5, 6 ],
    [ 7, 8, 9 ]
]
You should return

[1, 2, 3, 6, 9, 8, 7, 4, 5]
Problem Approach :

VIDEO : https://www.youtube.com/watch?v=siKFOI8PNKM


class Solution {
    public List<int> spiralOrder(List<List<int>> A) { ... }
}

 */

class Solution {
    public List<int> spiralOrder(List<List<int>> arr)
    {
        return SpiralOrder(arr).ToList();
    }


    public static IEnumerable<int> SpiralOrder(List<List<int>> arr, Direction direction = Direction.right)
    {
        int T = 0, L = 0, B = Math.Max(arr.Count - 1, 0), R =  Math.Max(arr[0].Count - 1, 0);

        while (T <= B && L <= R)
        {
            switch (direction)
            {
                case Direction.right:
                {
                    for (int i = L; i <= R; i++)
                        yield return arr[T][i];

                    T++;
                    direction = Direction.down;
                }
                    break;

                case Direction.down:
                {
                    for (int i = T; i <= B; i++)
                        yield return arr[i][R];

                    R--;
                    direction = Direction.left;
                }
                    break;

                case Direction.left:
                {
                    for (int i = R; i >= L; i--)
                        yield return arr[B][i];

                    B--;
                    direction = Direction.up;

                }
                    break;

                case Direction.up:
                {
                    for (int i = B; i >= T; i--)
                        yield return arr[i][L];

                    L++;
                    direction = Direction.right;
                }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }

    internal enum Direction { right, down, left, up }
}

public class SpiralOrderMatrixTests
{
    [Test]
    public void SpiralOrderTestCase1()
    {
        IEnumerable<int> result = Solution.SpiralOrder(new List<List<int>>()
        {
            new() { 1, 2, 3 },
            new() { 4, 5, 6 },
            new() { 7, 8, 9 },
        });

        List<int> list = result.ToList();
        list.Should().Equal(new List<int>
        {
            1, 2, 3, 
            6, 9, 
            8, 7, 
            4, 
            5
        });
    }

    [Test]
    public void SpiralOrderTestCase2()
    {
        IEnumerable<int> result = Solution.SpiralOrder(new List<List<int>>()
        {
            new() { 1, 2},
        });

        List<int> list = result.ToList();
        list.Should().Equal(new List<int>
        {
            1, 2
        });
    }

    [Test]
    public void SpiralOrderTestCase3()
    {
        IEnumerable<int> result = Solution.SpiralOrder(new List<List<int>>()
        {
            new() { 335, 401, 128, 384, 345, 275, 324, 139, 127, 343, 197, 177, 127, 72, 13, 59 },
            new() { 102, 75, 151, 22, 291, 249, 380, 151, 85, 217, 246, 241, 204, 197, 227, 96 },
            new() { 261, 163, 109, 372, 238, 98, 273, 20, 233, 138, 40, 246, 163, 191, 109, 237 },
            new() { 179, 213, 214, 9, 309, 210, 319, 68, 400, 198, 323, 135, 14, 141, 15, 168 },
        });

        List<int> list = result.ToList();
        list.Should().Equal(new List<int>
        {
            335, 401, 128, 384, 345, 275, 324, 139, 127, 343, 197, 177, 127, 72, 13, 59, 96, 237, 168, 15, 141, 14, 135, 323, 198, 400, 68, 319, 210, 309, 9, 214, 213, 179, 261, 102, 75, 151, 22, 291, 249, 380, 151, 85, 217, 246, 241, 204, 197, 227, 109, 191, 163, 246, 40, 138, 233, 20, 273, 98, 238, 372, 109, 163
        });
    }

}
