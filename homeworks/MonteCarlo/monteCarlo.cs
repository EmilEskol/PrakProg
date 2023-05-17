using System;
using static System.Console;
using static System.Math;
using static matrix;

public static class monteCarlo{
	public static (double,double) plMonteCarlo(Func<vector,double> f, vector a, vector b, int N){
		var rnd=new Random();
		int dim=a.size;
		vector x = new vector(dim);
		double V=1;
		double fx,sum=0,sum2=0;
		for(int i=0;i<dim;i++){
			V*=b[i]-a[i];
		}
		for(int i=0;i<N;i++){
			for(int j=0;j<dim;j++){
				x[j]=a[j]+rnd.NextDouble()*(b[j]-a[j]);
			}
			fx=f(x);
			sum+=fx;
			sum2+=fx*fx;
		}
		double mean=sum/N;
		var result=(mean*V,V/Sqrt(N)*Sqrt(sum2/N-mean*mean));
	return result;	
	}
	public static (double,double) qMonteCarlo(Func<vector,double> f, vector a, vector b, int N){
		int dim=a.size;
		vector x1 = new vector(dim);
		vector x2 = new vector(dim);
		vector hal1 = new vector(dim);
		vector hal2 = new vector(dim);
		double V=1;
		double fx1,fx2,sum1=0,sum2=0;
		for(int i=0;i<dim;i++){
			V*=b[i]-a[i];
		}
		for(int i=0;i<N;i++){
			x1=halton(i+1,dim);
			x2=halton(i+dim,dim);
			for(int j=0;j<dim;j++){
				hal1[j]=x1[j]*(b[j]-a[j]);
				hal2[j]=x2[j]*(b[j]-a[j]);
			}
			x1=a+hal1;
			x2=a+hal2;
			fx1=f(x1);
			fx2=f(x2);
			sum1+=fx1;
			sum2+=fx2;
		}
		double mean1=sum1/N;
		double mean2=sum2/N;
		var result=(mean1*V,Abs(mean1-mean2)*V);
		return result;
	}
	public static double corput(int n, int b){
		double bk=1.0/b;
		double q=0;
		while(n>0){
			q += (n%b)*bk;
			n/=b;
			bk/=b;
		}
		return q;
	}
	public static vector halton(int n, int d){
		vector x=new vector(d);
		int[] b = {2,3,5,7,11,13,17,19,23,299,31,37,41,43,43,47,53,59,61,67, 71, 73, 79, 83, 89, 97};
		for(int i=0;i<d;i++){
			x[i]=corput(n,b[i]);
		}
		return x;
	}	
}
