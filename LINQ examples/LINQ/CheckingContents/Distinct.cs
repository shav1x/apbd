﻿namespace LINQ.CheckingContents;

public class Distinct : QueryRunner
{
    public override void Run()
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Remove duplicates from a source.
    /// </summary>
    private void RemoveDuplicateItems()
    {
        int[] sourceItems = [1, 3, 5, 3, 7, 7, 1, 6, 15, 23];

        var result = sourceItems.Distinct();
        
        PrintAll(result);
    }
    
    /// <summary>
    /// Remove duplicates from a source, based on a certain key.
    /// </summary>
    private void RemoveDuplicateItemsByKey()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = sourceMovies
            .DistinctBy(movie => movie.Phase);

        PrintAll(query);
    }
}