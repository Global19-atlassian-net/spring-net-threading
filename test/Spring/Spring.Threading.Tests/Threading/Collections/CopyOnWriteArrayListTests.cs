using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;
using Spring.Collections;

namespace Spring.Threading.Collections
{
	[TestFixture]
	public class CopyOnWriteArrayListTests : BaseThreadingTestCase
	{
		internal static CopyOnWriteArrayList populatedArray( int n )
		{
			CopyOnWriteArrayList a = new CopyOnWriteArrayList();
			Assert.IsTrue( a.IsEmpty );
			for ( int i = 0; i < n; ++i )
			{
				a.Add( i );
			}
			Assert.IsFalse( a.IsEmpty );
			Assert.AreEqual( n, a.Count );
			return a;
		}

		[Test]
		public void Constructor()
		{
			CopyOnWriteArrayList a = new CopyOnWriteArrayList();
			Assert.IsTrue( a.IsEmpty );
		}

		[Test]
		public void Constructor2()
		{
			Int32[] ints = new Int32[DEFAULT_COLLECTION_SIZE];
			for ( int i = 0; i < DEFAULT_COLLECTION_SIZE - 1; ++i )
			{
				ints[i] = i;
			}

			CopyOnWriteArrayList a = new CopyOnWriteArrayList( ints );
			for ( int i = 0; i < DEFAULT_COLLECTION_SIZE; ++i )
			{
				Assert.AreEqual( ints[i], a[i] );
			}
		}

		[Test]
		[ExpectedException( typeof ( ArgumentNullException ) )]
		public void ConstructorCollectionNull()
		{
			new CopyOnWriteArrayList( null );
		}

		[Test]
		public void Constructor3()
		{
			Int32[] ints = new Int32[DEFAULT_COLLECTION_SIZE];
			for ( int i = 0; i < DEFAULT_COLLECTION_SIZE - 1; ++i )
			{
				ints[i] = i;
			}

			CopyOnWriteArrayList a = new CopyOnWriteArrayList( new ArrayList( ints ) );
			for ( int i = 0; i < DEFAULT_COLLECTION_SIZE; ++i )
			{
				Assert.AreEqual( ints[i], a[i] );
			}
		}

		[Test]
		public void AddAll()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			ArrayList v = ArrayList.Synchronized( new ArrayList( 10 ) );
			v.Add( three );
			v.Add( four );
			v.Add( five );
			full.AddAll( v );
			Assert.AreEqual( 6, full.Count );
		}

		[Test]
		public void AddAllAbsent()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			ArrayList v = ArrayList.Synchronized( new ArrayList( 10 ) );
			v.Add( three );
			v.Add( four );
			v.Add( one ); // will not add this element
			full.AddAllAbsent( v );
			Assert.AreEqual( 5, full.Count );
		}

		[Test]
		public void AddIfAbsent()
		{
			CopyOnWriteArrayList full = populatedArray( DEFAULT_COLLECTION_SIZE );
			full.AddIfAbsent( one );
			Assert.AreEqual( DEFAULT_COLLECTION_SIZE, full.Count );
		}

		[Test]
		public void AddIfAbsent2()
		{
			CopyOnWriteArrayList full = populatedArray( DEFAULT_COLLECTION_SIZE );
			full.AddIfAbsent( three );
			Assert.IsTrue( full.Contains( three ) );
		}

		[Test]
		public void Clear()
		{
			CopyOnWriteArrayList full = populatedArray( DEFAULT_COLLECTION_SIZE );
			full.Clear();
			Assert.AreEqual( 0, full.Count );
		}

		[Test]
		public void Clone()
		{
			CopyOnWriteArrayList l1 = populatedArray( DEFAULT_COLLECTION_SIZE );
			CopyOnWriteArrayList l2 = (CopyOnWriteArrayList) ( l1.Clone() );
			Assert.AreEqual( l1, l2 );
			l1.Clear();
			Assert.IsFalse( l1.Equals( l2 ) );
		}

		[Test]
		public void Contains()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			Assert.IsTrue( full.Contains( one ) );
			Assert.IsFalse( full.Contains( five ) );
		}

		[Test]
		public void AddIndex()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			full.Insert( 0, m1 );
			Assert.AreEqual( 4, full.Count );
			Assert.AreEqual( m1, full[0] );
			Assert.AreEqual( zero, full[1] );

			full.Insert( 2, m2 );
			Assert.AreEqual( 5, full.Count );
			Assert.AreEqual( m2, full[2] );
			Assert.AreEqual( two, full[4] );
		}

		[Test]
		public void Equals()
		{
			CopyOnWriteArrayList a = populatedArray( 3 );
			CopyOnWriteArrayList b = populatedArray( 3 );
			Assert.IsTrue( a.Equals( b ) );
			Assert.IsTrue( b.Equals( a ) );
			Assert.AreEqual( a.GetHashCode(), b.GetHashCode() );
			a.Add( m1 );
			Assert.IsFalse( a.Equals( b ) );
			Assert.IsFalse( b.Equals( a ) );
			b.Add( m1 );
			Assert.IsTrue( a.Equals( b ) );
			Assert.IsTrue( b.Equals( a ) );
			Assert.AreEqual( a.GetHashCode(), b.GetHashCode() );
		}

		[Test]
		public void ContainsAll()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			ArrayList v = ArrayList.Synchronized( new ArrayList( 10 ) );
			v.Add( one );
			v.Add( two );
			Assert.IsTrue( full.ContainsAll( v ) );
			v.Add( six );
			Assert.IsFalse( full.ContainsAll( v ) );
		}

		[Test]
		public void Get()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			Assert.AreEqual( 0, ( (Int32) full[0] ) );
		}

		[Test]
		public void IndexOf()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			Assert.AreEqual( 1, full.IndexOf( one ) );
			Assert.AreEqual( - 1, full.IndexOf( "puppies" ) );
		}

		[Test]
		public void IndexOf2()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			Assert.AreEqual( 1, full.IndexOf( one, 0 ) );
			Assert.AreEqual( - 1, full.IndexOf( one, 2 ) );
		}

		[Test]
		public void IsEmpty()
		{
			CopyOnWriteArrayList empty = new CopyOnWriteArrayList();
			CopyOnWriteArrayList full = populatedArray( DEFAULT_COLLECTION_SIZE );
			Assert.IsTrue( empty.IsEmpty );
			Assert.IsFalse( full.IsEmpty );
		}

		[Test]
		public void Iterator()
		{
			CopyOnWriteArrayList full = populatedArray( DEFAULT_COLLECTION_SIZE );
			IEnumerator i = full.GetEnumerator();
			int j;

			for ( j = 0; i.MoveNext(); j++ )
			{
				Assert.AreEqual( j, ( (Int32) i.Current ) );
			}
			Assert.AreEqual( DEFAULT_COLLECTION_SIZE, j );
		}

		[Test]
		public void CopyOnWriteArrayListToString()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			String s = full.ToString();
			for ( int i = 0; i < 3; ++i )
			{
				Assert.IsTrue( s.IndexOf( Convert.ToString( i ) ) >= 0 );
			}
		}

		[Test]
		public void LastIndexOf1()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			full.Add( one );
			full.Add( three );
			Assert.AreEqual( 3, full.LastIndexOf( one ) );
			Assert.AreEqual( - 1, full.LastIndexOf( six ) );
		}

		[Test]
		public void lastIndexOf2()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			full.Add( one );
			full.Add( three );
			Assert.AreEqual( 3, full.LastIndexOf( one, 4 ) );
			Assert.AreEqual( - 1, full.LastIndexOf( three, 3 ) );
		}

		[Test]
		public void ListIterator1()
		{
			CopyOnWriteArrayList full = populatedArray( DEFAULT_COLLECTION_SIZE );
			IEnumerator i = full.GetEnumerator();
			int j;

			for ( j = 0; i.MoveNext(); j++ )
			{
				Assert.AreEqual( j, ( (Int32) i.Current ) );
			}
			Assert.AreEqual( DEFAULT_COLLECTION_SIZE, j );
		}

		[Test]
		public void Remove()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			full.Remove( 2 );
			Assert.AreEqual( 2, full.Count );
		}

		[Test]
		public void RemoveAll()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			ArrayList v = ArrayList.Synchronized( new ArrayList( 10 ) );
			v.Add( one );
			v.Add( two );
			full.RemoveAll( v );
			Assert.AreEqual( 1, full.Count );
		}

		[Test]
		public void Set()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			full[2] = four;
			Assert.AreEqual( 4, ( (Int32) full[2] ) );
		}

		[Test]
		public void Size()
		{
			CopyOnWriteArrayList empty = new CopyOnWriteArrayList();
			CopyOnWriteArrayList full = populatedArray( DEFAULT_COLLECTION_SIZE );
			Assert.AreEqual( DEFAULT_COLLECTION_SIZE, full.Count );
			Assert.AreEqual( 0, empty.Count );
		}

		[Test]
		public void ToArray()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			Object[] o = full.ToArray();
			Assert.AreEqual( 3, o.Length );
			Assert.AreEqual( 0, ( (Int32) o[0] ) );
			Assert.AreEqual( 1, ( (Int32) o[1] ) );
			Assert.AreEqual( 2, ( (Int32) o[2] ) );
		}

		[Test]
		public void ToArray2()
		{
			CopyOnWriteArrayList full = populatedArray( 3 );
			object[] i = new object[3];

			i = full.ToArray( i );
			Assert.AreEqual( 3, i.Length );
			Assert.AreEqual( 0, i[0] );
			Assert.AreEqual( 1, i[1] );
			Assert.AreEqual( 2, i[2] );
		}

		[Test]
		[ExpectedException( typeof ( IndexOutOfRangeException ) )]
		public void Get1_IndexOutOfBoundsException()
		{
			CopyOnWriteArrayList c = new CopyOnWriteArrayList();
			Object generatedAux = c[- 1];
		}

		[Test]
		[ExpectedException( typeof ( IndexOutOfRangeException ) )]
		public void Get2_IndexOutOfBoundsException()
		{
			CopyOnWriteArrayList c = new CopyOnWriteArrayList();
			c.Add( "asdasd" );
			c.Add( "asdad" );
			Object generatedAux = c[100];
		}

		[Test]
		[ExpectedException( typeof ( IndexOutOfRangeException ) )]
		public void Set1_IndexOutOfBoundsException()
		{
			CopyOnWriteArrayList c = new CopyOnWriteArrayList();
			c[-1] = "qwerty";
		}

		[Test]
		[ExpectedException( typeof ( IndexOutOfRangeException ) )]
		public void Set2()
		{
			CopyOnWriteArrayList c = new CopyOnWriteArrayList();
			c.Add( "asdasd" );
			c.Add( "asdad" );
			c[100] = "qwerty";
		}

		[Test]
		[ExpectedException( typeof ( IndexOutOfRangeException ) )]
		public void Add1_IndexOutOfBoundsException()
		{
			CopyOnWriteArrayList c = new CopyOnWriteArrayList();
			c.Insert( - 1, "qwerty" );
		}

		[Test]
		[ExpectedException( typeof ( IndexOutOfRangeException ) )]
		public void Add2_IndexOutOfBoundsException()
		{
			CopyOnWriteArrayList c = new CopyOnWriteArrayList();
			c.Add( "asdasd" );
			c.Add( "asdasdasd" );
			c.Insert( 100, "qwerty" );
		}

		[Test]
		[ExpectedException( typeof ( IndexOutOfRangeException ) )]
		public void Remove1_IndexOutOfBounds()
		{
			CopyOnWriteArrayList c = new CopyOnWriteArrayList();
			c.RemoveAt( - 1 );
		}

		[Test]
		[ExpectedException( typeof ( IndexOutOfRangeException ) )]
		public void Remove2_IndexOutOfBounds()
		{
			CopyOnWriteArrayList c = new CopyOnWriteArrayList();
			c.Add( "asdasd" );
			c.Add( "adasdasd" );
			c.RemoveAt( 100 );
		}

		[Test]
		[ExpectedException( typeof ( IndexOutOfRangeException ) )]
		public void AddAll1_IndexOutOfBoundsException()
		{
			CopyOnWriteArrayList c = new CopyOnWriteArrayList();
			c.AddAll( - 1, new LinkedList() );
		}

		[Test]
		[ExpectedException( typeof ( IndexOutOfRangeException ) )]
		public void AddAll2_IndexOutOfBoundsException()
		{
			CopyOnWriteArrayList c = new CopyOnWriteArrayList();
			c.Add( "asdasd" );
			c.Add( "asdasdasd" );
			c.AddAll( 100, new LinkedList() );
		}

		[Test]
		public void Serialization()
		{
			CopyOnWriteArrayList q = populatedArray( DEFAULT_COLLECTION_SIZE );
			MemoryStream bout = new MemoryStream( 10000 );

			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize( bout, q );

			MemoryStream bin = new MemoryStream( bout.ToArray() );
			BinaryFormatter formatter2 = new BinaryFormatter();
			CopyOnWriteArrayList r = (CopyOnWriteArrayList) formatter2.Deserialize( bin );

			Assert.AreEqual( q.Count, r.Count );
			Assert.IsTrue( q.Equals( r ) );
			Assert.IsTrue( r.Equals( q ) );
		}
	}
}