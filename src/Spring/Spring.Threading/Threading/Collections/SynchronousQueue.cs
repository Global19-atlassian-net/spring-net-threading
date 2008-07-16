using System;
using System.Collections;
using Spring.Collections;

namespace Spring.Threading.Collections
{
	/// <summary>
	/// Summary description for SynchronousQueue.
	/// </summary>
	public class SynchronousQueue : IBlockingQueue
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="array"></param>
		/// <param name="index"></param>
		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// 
		/// </summary>
		public int Count
		{
			get { throw new NotImplementedException(); }
		}
		/// <summary>
		/// 
		/// </summary>
		public object SyncRoot
		{
			get { throw new NotImplementedException(); }
		}

		/// <summary> 
		/// Inserts the specified element into this queue if it is possible to do so
		/// immediately without violating capacity restrictions, returning
		/// <see lang="true"/> upon success and throwing an
		/// <see cref="ArgumentException"/> if no space is
		/// currently available.
		/// </summary>
		/// <param name="objectToAdd">
		/// The element to add.
		/// </param>
		/// <returns> 
		/// <see lang="true"/> if successful.
		/// </returns>
		/// <exception cref="InvalidCastException">
		/// If the element cannot be added at this time due to capacity restrictions.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// If the class of the supplied <paramref name="objectToAdd"/> prevents it
		/// from being added to this queue.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// If the specified element is <see lang="null"/> and this queue does not
		/// permit <see lang="null"/> elements.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// If some property of the supplied <paramref name="objectToAdd"/> prevents
		/// it from being added to this queue.
		/// </exception>
		public bool Add(object objectToAdd)
		{
			throw new NotImplementedException();
		}

		/// <summary> 
		/// Inserts the specified element into this queue if it is possible to do
		/// so immediately without violating capacity restrictions.
		/// </summary>
		/// <remarks>
		/// <p>
		/// When using a capacity-restricted queue, this method is generally
		/// preferable to <see cref="ArgumentNullException"/>,
		/// which can fail to insert an element only by throwing an exception.
		/// </p>
		/// </remarks>
		/// <param name="objectToAdd">
		/// The element to add.
		/// </param>
		/// <returns>
		/// <see lang="true"/> if the element was added to this queue.
		/// </returns>
		/// <exception cref="ArgumentException">
		/// If the element cannot be added at this time due to capacity restrictions.
		/// </exception>
		/// <exception cref="IQueue.Add">
		/// If the supplied <paramref name="objectToAdd"/> is
		/// <see lang="null"/> and this queue does not permit <see lang="null"/>
		/// elements.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// If some property of the supplied <paramref name="objectToAdd"/> prevents
		/// it from being added to this queue.
		/// </exception>
		public bool Offer(object objectToAdd)
		{
			throw new NotImplementedException();
		}

		/// <summary> 
		/// Retrieves and removes the head of this queue.
		/// </summary>
		/// <remarks>
		/// <p>
		/// This method differs from <see cref="Spring.Collections.IQueue.Poll()"/>
		/// only in that it throws an exception if this queue is empty.
		/// </p>
		/// </remarks>
		/// <returns> 
		/// The head of this queue
		/// </returns>
		/// <exception cref="Spring.Collections.NoElementsException">if this queue is empty</exception>
		public object Remove()
		{
			throw new NotImplementedException();
		}

		/// <summary> 
		/// Retrieves and removes the head of this queue,
		/// or returns <see lang="null"/> if this queue is empty.
		/// </summary>
		/// <returns> 
		/// The head of this queue, or <see lang="null"/> if this queue is empty.
		/// </returns>
		public object Poll()
		{
			throw new NotImplementedException();
		}

		/// <summary> 
		/// Retrieves, but does not remove, the head of this queue.
		/// </summary>
		/// <remarks>
		/// <p>
		/// This method differs from <see cref="NoElementsException"/>
		/// only in that it throws an exception if this queue is empty.
		/// </p>
		/// </remarks>
		/// <returns> 
		/// The head of this queue.
		/// </returns>
		/// <exception cref="IQueue.Peek">If this queue is empty.</exception>
		public object Element()
		{
			throw new NotImplementedException();
		}

		/// <summary> 
		/// Inserts the specified element into this queue, waiting if necessary
		/// for space to become available.
		/// </summary>
		/// <param name="objectToAdd">the element to add</param>
		/// <exception cref="InvalidCastException">
		/// If the element cannot be added at this time due to capacity restrictions.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// If the class of the supplied <paramref name="objectToAdd"/> prevents it
		/// from being added to this queue.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// If the specified element is <see lang="null"/> and this queue does not
		/// permit <see lang="null"/> elements.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// If some property of the supplied <paramref name="objectToAdd"/> prevents
		/// it from being added to this queue.
		/// </exception>
		public void Put(object objectToAdd)
		{
			throw new NotImplementedException();
		}

		/// <summary> 
		/// Inserts the specified element into this queue, waiting up to the
		/// specified wait time if necessary for space to become available.
		/// </summary>
		/// <param name="objectToAdd">the element to add</param>
		/// <param name="duration">how long to wait before giving up</param>
		/// <returns> <see lang="true"/> if successful, or <see lang="false"/> if
		/// the specified waiting time elapses before space is available
		/// </returns>
		/// <exception cref="ArgumentException">
		/// If the element cannot be added at this time due to capacity restrictions.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// If the class of the supplied <paramref name="objectToAdd"/> prevents it
		/// from being added to this queue.
		/// </exception>
		/// <exception cref="InvalidCastException">
		/// If the specified element is <see lang="null"/> and this queue does not
		/// permit <see lang="null"/> elements.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// If some property of the supplied <paramref name="objectToAdd"/> prevents
		/// it from being added to this queue.
		/// </exception>
		public bool Offer(object objectToAdd, TimeSpan duration)
		{
			throw new NotImplementedException();
		}

		/// <summary> 
		/// Retrieves and removes the head of this queue, waiting if necessary
		/// until an element becomes available.
		/// </summary>
		/// <returns> the head of this queue</returns>
		public object Take()
		{
			throw new NotImplementedException();
		}

		/// <summary> 
		/// Retrieves and removes the head of this queue, waiting up to the
		/// specified wait time if necessary for an element to become available.
		/// </summary>
		/// <param name="duration">how long to wait before giving up</param>
		/// <returns> 
		/// the head of this queue, or <see lang="null"/> if the
		/// specified waiting time elapses before an element is available
		/// </returns>
		public object Poll(TimeSpan duration)
		{
			throw new NotImplementedException();
		}

		/// <summary> 
		/// Returns the number of additional elements that this queue can ideally
		/// (in the absence of memory or resource constraints) accept without
		/// blocking, or <see cref="IBlockingQueue.RemainingCapacity"/> if there is no intrinsic
		/// limit.
		/// 
		/// <p/>
		/// Note that you <b>cannot</b> always tell if an attempt to insert
		/// an element will succeed by inspecting <see cref="int.MaxValue"/>
		/// because it may be the case that another thread is about to
		/// insert or remove an element.
		/// </summary>
		/// <returns> the remaining capacity</returns>
		public int RemainingCapacity
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary> 
		/// Removes all available elements from this queue and adds them
		/// to the given collection.  
		/// </summary>
		/// <remarks>
		/// This operation may be more
		/// efficient than repeatedly polling this queue.  A failure
		/// encountered while attempting to add elements to
		/// collection <paramref name="collection"/> may result in elements being in neither,
		/// either or both collections when the associated exception is
		/// thrown.  Attempts to drain a queue to itself result in
		/// <see cref="System.ArgumentException"/>. Further, the behavior of
		/// this operation is undefined if the specified collection is
		/// modified while the operation is in progress.
		/// </remarks>
		/// <param name="collection">the collection to transfer elements into</param>
		/// <returns> the number of elements transferred</returns>
		/// <exception cref="ArgumentException">
		/// If the queue cannot be drained at this time.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// If the class of the supplied <paramref name="collection"/> prevents it
		/// from being used for the elemetns from the queue.
		/// </exception>
		/// <exception cref="InvalidCastException">
		/// If the specified collection is <see lang="null"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// If <paramref name="collection"/> represents the queue itself.
		/// </exception>
		public int DrainTo(ICollection collection)
		{
			throw new NotImplementedException();
		}

		/// <summary> Removes at most the given number of available elements from
		/// this queue and adds them to the given collection.  
		/// </summary>
		/// <remarks> 
		/// This operation may be more
		/// efficient than repeatedly polling this queue.  A failure
		/// encountered while attempting to add elements to
		/// collection <paramref name="collection"/> may result in elements being in neither,
		/// either or both collections when the associated exception is
		/// thrown.  Attempts to drain a queue to itself result in
		/// <see cref="System.ArgumentException"/>. Further, the behavior of
		/// this operation is undefined if the specified collection is
		/// modified while the operation is in progress.
		/// </remarks>
		/// <param name="collection">the collection to transfer elements into</param>
		/// <param name="maxElements">the maximum number of elements to transfer</param>
		/// <returns> the number of elements transferred</returns>
		/// <exception cref="ArgumentException">
		/// If the queue cannot be drained at this time.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// If the class of the supplied <paramref name="collection"/> prevents it
		/// from being used for the elemetns from the queue.
		/// </exception>
		/// <exception cref="InvalidCastException">
		/// If the specified collection is <see lang="null"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// If <paramref name="collection"/> represents the queue itself.
		/// </exception>
		public int DrainTo(ICollection collection, int maxElements)
		{
			throw new NotImplementedException();
		}

		/// <summary> 
		/// Retrieves, but does not remove, the head of this queue,
		/// or returns <see lang="null"/> if this queue is empty.
		/// </summary>
		/// <returns> 
		/// The head of this queue, or <see lang="null"/> if this queue is empty.
		/// </returns>
		public object Peek()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns <see lang="true" /> if there are no elements in the <see cref="T:Spring.Collections.IQueue" />, <see lang="false" /> otherwise.
		/// </summary>
		public bool IsEmpty
		{
			get { throw new NotImplementedException(); }
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsSynchronized
		{
			get { throw new NotImplementedException(); }
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}