using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;

namespace NunitRestSharpTestFramework
{
    public class TestCaseData
    {
        public string testCaseName { get; set; }
        public string executeValue { get; set; }
        public string environment { get; set; }
        public string uri { get; set; }

    }

    public class TestCaseConfiguration
    {

        public List<TestCaseData> testCaseConfigurationReader(String testCaseName, string testCaseConfigurationLocation)
        {
            string con = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + testCaseConfigurationLocation + ";" + @"Extended Properties='Excel 12.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from[Sheet1$] where TestCaseName ='" + testCaseName + "'", connection);
                using (OleDbDataReader dataReader = command.ExecuteReader())
                {
                    List<TestCaseData> readList = new List<TestCaseData>();
                    TestCaseData testCaseData = new TestCaseData();
                    if (dataReader.Read())
                    {
                        testCaseData.testCaseName = dataReader[0]!=DBNull.Value?"Yes":"NA";
                        testCaseData.executeValue = dataReader[1]!=DBNull.Value?"Yes":"NA";
                        testCaseData.environment =  dataReader[2]!=DBNull.Value?"Yes":"NA";
                        testCaseData.uri = dataReader[3]!=DBNull.Value?"Yes":"NA";
                        readList.Add(testCaseData);
                        return readList;
                    }
                    testCaseData.testCaseName = "NA";
                    testCaseData.executeValue = "NA";
                    testCaseData.environment = "NA";
                    testCaseData.uri = "NA";
                    readList.Add(testCaseData);
                    return readList;
                }
            }
        }

      
    }
}