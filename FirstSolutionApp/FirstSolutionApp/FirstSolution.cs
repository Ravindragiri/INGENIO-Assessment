using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6 {
    public class FirstSolution
    {
        public List<Result> GetSampleDataSet()
        {
            List<Result> result = new List<Result>() {
            new Result () {
                    CategoryId = 100,
                        ParentCategoryId = -1,
                        Name = "Business",
                        Keywords = "Money"
                },
                new Result () {
                    CategoryId = 200,
                        ParentCategoryId = -1,
                        Name = "Tutoring",
                        Keywords = "Teaching"
                },
                new Result () {
                    CategoryId = 101,
                        ParentCategoryId = 100,
                        Name = "Accounting",
                        Keywords = "Taxes"
                },
                new Result () {
                    CategoryId = 102,
                        ParentCategoryId = 100,
                        Name = "Taxation"
                },
                new Result () {
                    CategoryId = 201,
                        ParentCategoryId = 200,
                        Name = "Computer"
                },
                new Result () {
                    CategoryId = 103,
                        ParentCategoryId = 101,
                        Name = "Corporate Tax"
                },
                new Result () {
                    CategoryId = 202,
                        ParentCategoryId = 201,
                        Name = "Operating System"
                },
                new Result () {
                    CategoryId = 109,
                        ParentCategoryId = 101,
                        Name = "Small business Taxt"
                },
            };
            return result;
        }

        public Result GetResult(int categoryId)
        {
            var result = default(Result);
            var dataSet = GetSampleDataSet();
            if (dataSet != null)
            {
                var firstResult = dataSet.Where(e => e.CategoryId == categoryId).FirstOrDefault();
                if (firstResult != null && string.IsNullOrEmpty(firstResult.Keywords))
                {
                    result = GetKeywordResult(firstResult.CategoryId);
                    result.Name = firstResult.Name;
                    result.ParentCategoryId = firstResult.ParentCategoryId;
                }
            }
            return result;
        }

        public Result GetKeywordResult(int categoryId)
        {
            string keyword = string.Empty;
            var dataSet = GetSampleDataSet();
            if(dataSet != null)
            {
                var result = dataSet.Where(e => e.CategoryId == categoryId).FirstOrDefault();
                if(result != null)
                {
                    if (!string.IsNullOrEmpty(result.Keywords))
                        return result;
                    return GetKeywordResult(result.ParentCategoryId);
                }
            }
            return default(Result);
        }
    }
}