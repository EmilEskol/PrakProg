using static matrix;
using static System.Console;

public static class QRGS{
	public static (matrix,matrix) decomp(matrix A){
		int m=A.size2;
		matrix Q=A.copy();
		matrix R=new matrix(m,m);
		for(int i=0;i<m;i++){
			R[i,i]=Q[i].norm();
			Q[i]/=R[i,i];
			for(int j=i+1;j<m;j++){
				R[i,j]=Q[i].dot(Q[j]);
				Q[j]-=Q[i]*R[i,j];
			}
		}
		return (Q,R);
	}
	public static vector solve(matrix Q,matrix R, vector b){
		int n=Q.size1;int m=Q.size2;
		vector x=Q.T*b;
		for(int i=0;i<m;i++){
			for(int j=0;j<i;j++){
				x[m-i-1]-=x[m-j-1]*R[n-1-i,m-j-1];
				//WriteLine($"i,j={n-i},{m-j} x*R={x[m-j-1]}*{R[n-1-i,m-1-j]}={x[m-j-1]*R[n-1-i,m-1-j]}");
			}
			//WriteLine($"i={n-i}:x={x[m-1-i]} R={R[n-1-i,m-1-i]}");
			x[m-i-1]/=R[n-1-i,m-1-i];
		}
		return x;
	}
	public static double det(matrix R){
		double det=1;
		//Because R is right triangular the determinant is the product of the diagonals
		for(int n=0;n<R.size1;n++){
			det *=R[n,n];
		}
		return det;
	}
	public static matrix inverse(matrix Q,matrix R){
		int n=Q.size1;int m=Q.size2;
		matrix B=new matrix(n,m);
		vector e=new vector(m);
		e[0]=1;
		for(int i=0;i<m;i++){
			B[i]=solve(Q,R,e);
			e[i]=0;
			if(i!=m-1)
				e[i+1]=1;
		}
		return B;
	}
}
