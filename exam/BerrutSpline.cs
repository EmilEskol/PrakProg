using System;
using System.Threading;
using static System.Console;
using static System.Math;
using static vector;
public class BerrutSpline{
	public class data{
		public int a,b;
		public double z,numerab,denomab;
		public double[] xs,ys;
	}
	
	vector x;
	double numer,denom;//numerater and denominator
	int n,nThreads;
	data[] locs;
	
	public BerrutSpline(string[] args, vector xs,vector ys){
		n=xs.size;
		x=xs.copy();
		WriteLine($"Size of vectors {n}");
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-threads") 
				nThreads = (int)float.Parse(words[1]);
		}
		WriteLine($"N# of threads {nThreads} and N# data points {n}");
		locs = new data[nThreads];
		for(int i=0;i<nThreads;i++){
			locs[i] = new data();
			locs[i].a = (i*n)/nThreads;
			locs[i].b = ((i+1)*n)/nThreads;
			locs[i].xs=new double[locs[i].b-locs[i].a];
			locs[i].ys=new double[locs[i].b-locs[i].a];
			for(int j=locs[i].a;j<locs[i].b;j++){
				locs[i].xs[j-locs[i].a] = xs[j];
				locs[i].ys[j-locs[i].a] = ys[j];
			}
			WriteLine($"Thread number{i} has a={locs[i].a} b={locs[i].b}");
		}
	}
	public double evaluate(double z){
		numer=0;
		denom=0;
		for(int i=0;i<nThreads;i++){
			for(int j=0;j<locs[i].xs.Length;j++){
				if(z==locs[i].xs[j])
					return locs[i].ys[j];
			}
			locs[i].z=z;
		}
		Thread[] threads = new Thread[nThreads];
		for(int i=0;i<nThreads;i++){
			threads[i] = new Thread(Sum);
			threads[i].Start(locs[i]);
		}
		for(int i=0;i<nThreads;i++){
			threads[i].Join();
		}
		for(int i=0;i<nThreads;i++){
			numer+=locs[i].numerab;
			denom+=locs[i].denomab;
		}

		/*for(int i=0;i<n;i++){
			if(z==x[i])
				return y[i];
			numer+=Pow(-1,i)/(z-x[i])*y[i];
			denom+=Pow(-1,i)/(z-x[i]);
		}*/
		//WriteLine($"z {z} nomer {numer} denom {denom}");
		return numer/denom;
	}
	public void Sum(object obj){
		data loc= (data) obj;
		double x;
		loc.numerab=0;
		loc.denomab=0;
		for(int i=0;i<loc.b-loc.a;i++){
			x=loc.xs[i];
			loc.numerab+=Pow(-1,i)/(loc.z-x)*loc.ys[i];
			loc.denomab+=Pow(-1,i)/(loc.z-x);
		}
	}
	public (double[],double[]) printData(int m){
			int size=(n-1)*m;
			double step,x1,x2;
			double[] xData = new double[size];
			double[] yData = new double[size];
			for(int i=0;i<n-1;i++){
				for(int j=0;j<m;j++){
					x1=x[i];x2=x[i+1];
					step=(j-1)*(x2-x1)/m;
					xData[m*i+j]=x1+step;
					yData[m*i+j]=evaluate(x1+step);
				}
			}
		return (xData,yData);
	}
}
