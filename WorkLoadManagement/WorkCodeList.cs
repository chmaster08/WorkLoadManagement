using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class WorkCodeList
    {
        public List<string> workCodeList { get;private set; }

        public WorkCodeList()
        {
            workCodeList = new List<string>();
            DefaultSet();

        }

        public void Add(string item)
        {
            if(!workCodeList.Contains(item))
            {
                workCodeList.Add(item);
            }
        }
        public List<string> GetWorkCodeList()
        {
            return workCodeList;
        }
        public bool FindCode(string item)
        {
            return workCodeList.Contains(item);
        }
        public void Delete(string item)
        {
            if(workCodeList.Contains(item))
            {
                workCodeList.Remove(item);
            }
        }
        private void DefaultSet()
        {
            if(!workCodeList.Contains("Other"))
            {
                workCodeList.Add("Other");
            }
        }
    }
}
