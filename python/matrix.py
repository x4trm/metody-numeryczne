from det import Laplace,Delete_Row_Column
import numpy as np
from numpy.linalg import inv

def createMatrix(A,B):
    result=[]
    for i in range(len(A)):
        result.append([])
    for i in range(len(A)):
        for j in range(len(B[0])):
            result[i].append(0)
    return result

def multipleMatrix(A,B):
    result=createMatrix(A,B)
    for i in range(len(A)):
        for j in range(len(B[0])):
            for k in range(len(B)):
                result[i][j]+=A[i][k]*B[k][j]
    return result

def multipleScalarMatrix(A,x):
    for i in range(len(A)):
        for j in range(len(A[0])):
            A[i][j]*=x
    return A

def printMatrix(A):
    for i in A:
        print(i)
            
def transpose(A):
    result=createMatrix(A[0],A)
    for i in range(len(A)):
        for j in range(len(A[0])):
            result[j][i]=A[i][j]
    return result


def inverseMatrix(A):
    row,col=A.shape
    if row==col:
        det=Laplace(A)
        result=np.zeros_like(A)
        for i in range(row):
            for j in range(col):
                result[i,j]=1.0/det*Laplace(Delete_Row_Column(A,row,col))
                if (row+col)%2==1:
                    result[row,col]=-result[row,col]
    return transpose(result)    

def solveMatrix(A,B):
    return multipleMatrix(inv(A),B)


def gauss(A,B):
    n=len(B)
    for i in range(n):
        for j in range(n):
            if j!=i:
                temp=A[j,i]/A[i,i]
                for k in range(i+1,n+1):
                    if k!=n:
                        A[j,k]-=temp*A[i,k]
                    else:
                        B[j]-=temp*B[i]
    x = np.zeros(n)
    for i in range(n-1, -1, -1):
        x[i] = B[i]/A[i, i]
        for j in range (i-1, -1, -1):
            A[i, i] += A[j, i]*x[i]
    return x


def gauss_jordan(A,B):
    n=len(B)
    for i in range(n):
        for j in range(n):
            if j!=i:
                temp=A[j,i]/A[i,i]
                for k in range(i+1,n+1):
                    if k!=n:
                        A[j,k]-=temp*A[i,k]
                    else:
                        B[j]-=temp*B[i]
    x=np.zeros(n)
    for i in range(n):
        x[i]=B[i]/A[i,i]
    return x

def MatrixLU(A,L,U):
    row,col=A.shape
    for i in range(row):
        for j in range(row):
            if j>i:
                temp=A[j,i]/A[i,i]
                for k in range(col):
                    if k!=col:
                        A[j,k]=A[j,k]*temp*A[i,k]
                        if A[j,k]==0.0:
                            L[j,k]=temp
            elif j==i:
                L[i,j]=1.0
            U[i,j]=A[i,j]
    return L,U