from det import Laplace
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

def inverse(A):
    det=Laplace(A)
    if det!=0:
        return multipleScalarMatrix(transpose(A),(1/det))
    else:
        return

def solveMatrix(A,B):
    return multipleMatrix(inv(A),B)


def gauss(A,B):
    n=len(B)
    for k in range(0,n-1):
        for i in range(k+1,n):
            if [i,k]!=0.0:
                m=A[i,k]/A[k,k]
                A[i,k+1:n]=A[i,k+1:n]-m*A[k,k+1:n]
                B[i]=B[i]-m*B[k]
    for k in range(n-1,-1,-1):
        B[k]=(B[k]-np.dot(A[k,k+1:n],B[k+1:n]))/A[k,k]
    return B