
from matrix import multipleMatrix,printMatrix,inverse
from det import det2x2,det3x3,Laplace
from factorial import factorial
from naturalLogarithm import e
from complex import Complex



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
F=[
    [2,7,-1,3,2],
    [0,0,1,0,1],
    [-2,0,7,0,2],
    [-3,-2,4,5,3],
    [1,0,0,0,1]
]
print(Laplace(F))

