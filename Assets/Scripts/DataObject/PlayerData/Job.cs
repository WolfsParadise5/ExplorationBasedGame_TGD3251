using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class Job
{
    public bool isJobAvailable = false;
    public string jobDescription;
    public int jobPIncomePerMonth;

    public Job(bool isJobAvailable, string jobDescription, int jobPIncomePerMonth)
    {
        this.isJobAvailable = isJobAvailable;
        this.jobDescription = jobDescription;
        this.jobPIncomePerMonth = jobPIncomePerMonth;
    }
}
