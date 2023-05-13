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

}
