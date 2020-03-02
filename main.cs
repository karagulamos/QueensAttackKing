// Author: Alexander Karagulamos
// Remark: https://leetcode.com/submissions/detail/308692111/

public class Solution 
{
  private const int Dimension = 8;
  
  private static (int Row, int Col)[] _directions;
  
  static Solution() => _directions = new (int, int)[]
  {
    (-1,0),(-1,1),(0,1),(1,1),(1,0),(1,-1),(0,-1),(-1,-1)
  };
  
  public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king) 
  {
    var visited = queens.Aggregate(0L, (bvec, queen) => bvec | Mask(queen[0], queen[1]));
        
    var result = new List<IList<int>>();

    foreach(var direction in _directions)
    {
      var row = direction.Row + king[0];
      var col = direction.Col + king[1];
      
      while(row >= 0 && col >= 0 && row < Dimension && col < Dimension)
      {
        if(IsVisited(row, col))
        {
          result.Add(new[]{row, col}.ToList());
          break;
        }
        
        row += direction.Row;
        col += direction.Col;
      }
    }

    return result;

    bool IsVisited(int row, int col) => (visited & Mask(row, col)) != 0;
    long Mask(int row, int col) => 1L << row * Dimension + col;
  }   
}