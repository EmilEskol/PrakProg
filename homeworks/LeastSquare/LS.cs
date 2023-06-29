using System;
using static matrix;
using static System.Console;

public static class LS{
	public static (vector,matrix) LSfit(Func<double,double>[] fs, vector x, vector y, vector dy){
		int n=x.size,m=fs.Length;
		vector b=new vector(n);
		matrix A = new matrix(n,m);
		for(int i=0;i<n;i++){
			for(int j=0;j<m;j++){
			A[i,j]=fs[j](x[i])/dy[i];
			}
			b[i]=y[i]/dy[i];
		}
		//A.print("A:\n");
		(matrix Q,matrix R) = QRGS.decomp(A);
		vector c=QRGS.solve(Q,R,b);
		matrix cov=R.T*R;
		(matrix Q1,matrix R1)=QRGS.decomp(cov);
		cov=QRGS.inverse(Q1,R1);
		return (c,cov);
	}
}
