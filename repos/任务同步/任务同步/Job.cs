using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 任务同步
{
    public class Job
    {
        private SharedState _sharedState;
        public Job(SharedState sharedState)
        {
            _sharedState = sharedState;
        }
        public void DoTheJob() {
            for (int i = 0; i < 50000; i++)
            {
                _sharedState.State += 1;
            }
        }
    }
}
