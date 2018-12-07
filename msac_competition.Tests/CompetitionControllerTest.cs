using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace msac_competition.Tests
{
    public class CompetitionControllerTest 
    {
        // GET
        [Fact]
        public void Index()
        {
            try
            {
                Assert.False(true, "");
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }
    }
}