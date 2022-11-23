from matrix import MatrixLU,inverseMatrix
import numpy as np
from det import Delete_Row_Column
A=np.array([[3.,5.,2.],[1.,2.,0.],[3.,0.,4.]])
B=np.zeros_like(A)
C=np.zeros_like(A)

# L,U=MatrixLU(A,B,C)
# print(L)
# print("#"*30)
# print(U)


D=np.array([[1,3,2],[4,-1,2],[1,-1,0]])
def foo(A,b,c):
    return A[b:,c:]
# print(A)
# print(foo(A,1,1))
# print(A)
# print(A[:,:1])
# print(inverseMatrix(D))
