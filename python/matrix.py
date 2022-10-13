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

def printMatrix(A):
    for i in A:
        print(i)
