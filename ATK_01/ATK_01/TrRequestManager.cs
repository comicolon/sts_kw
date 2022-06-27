using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ATK_01
{
	public class TrRequestManager
	{
		Queue<Task> requesTrTaskQueue = new Queue<Task>(); // TR 요청 큐

		Thread taskWoker;

		public int requestDelay = 670;

		public TrRequestManager()
		{
			taskWoker = new Thread(delegate ()
			{
				while (true)
				{
					while(requesTrTaskQueue.Count > 0)
					{
						requesTrTaskQueue.Dequeue().RunSynchronously();
						Thread.Sleep(requestDelay);
					}
					Thread.Sleep(100);
				}
			});

			Run();
		}

		public void Run()
		{
			taskWoker.Start();
		}

		public void RequestTrData(Task task)
		{
			requesTrTaskQueue.Enqueue(task);
		}

	}
}
