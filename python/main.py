result=[
    [0,0],
    [0,0],
    [0,0]
]
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
# def createMatrix(A,B):
#     for i in range(len(A[1])):
#         for j in range(len(B[0])):
#             result[i][j]=0
#     return result
def multipleMatrix(A,B):
    # result=createMatrix(A,B)
    
    for i in range(len(A)):
        for j in range(len(B[0])):
            for k in range(len(B)):
                result[i][j]+=A[i][k]*B[k][j]
    for r in result:
        print(r)

multipleMatrix(A,B)


# wyznacznik 2x2
def det2x2(A):
    return A[0][0]*A[1][1]-A[0][1]*A[1][0]

# wyznacznik 3x3
def det3x3(A):
    a=A[0][0]*A[1][1]*A[2][2]+A[1][0]*A[2][1]*A[0][2]+A[2][0]*A[0][1]*A[1][2]
    b=A[1][0]*A[0][1]*A[2][2]+A[0][0]*A[2][1]*A[1][2]+A[2][0]*A[1][1]*A[0][2]
    return a-b
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

