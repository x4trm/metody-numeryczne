import numpy as np
# wyznacznik 2x2
def det2x2(A):
    return A[0][0]*A[1][1]-A[0][1]*A[1][0]

# wyznacznik 3x3
def det3x3(A):
    a=A[0][0]*A[1][1]*A[2][2]+A[1][0]*A[2][1]*A[0][2]+A[2][0]*A[0][1]*A[1][2]
    b=A[1][0]*A[0][1]*A[2][2]+A[0][0]*A[2][1]*A[1][2]+A[2][0]*A[1][1]*A[0][2]
    return a-b
def Delete_Row_Column(A,b,c):
    return A[b:,c:]

def Laplace(A):
    d=0
    if len(A)==1:
        return A[0][0]
    if len(A)==2:
        return A[0][0]*A[1][1]-A[0][1]*A[1][0]
    else:
        for c,e in enumerate(A[0]):
            K=[x[:c]+x[c+1:] for x in A[1:]]
            if c%2==0:
                s=1
            else:
                s=-1
            d+=s*e*Laplace(K)
        return d