
from matrix import multipleMatrix,printMatrix
from det import det2x2,det3x3
from factorial import factorial
from naturalLogarithm import e
print(e(26))
print(factorial(26))


A=[
    [-1,4,2,-2],
    [1,2,-3,0],
    [-1,0,0,5]
]
B=[
    [2,-1],
    [1,3],
    [-2,0],
    [0,-4]]

E=multipleMatrix(A,B)
printMatrix(E)


C=[
    [2,1],
    [2,2]]
D=[
    [1,3,2],
    [4,-1,2],
    [1,-1,0]
]
print(det2x2(C))
print(det3x3(D))


