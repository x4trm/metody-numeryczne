# wyznacznik 2x2
def det2x2(A):
    return A[0][0]*A[1][1]-A[0][1]*A[1][0]

# wyznacznik 3x3
def det3x3(A):
    a=A[0][0]*A[1][1]*A[2][2]+A[1][0]*A[2][1]*A[0][2]+A[2][0]*A[0][1]*A[1][2]
    b=A[1][0]*A[0][1]*A[2][2]+A[0][0]*A[2][1]*A[1][2]+A[2][0]*A[1][1]*A[0][2]
    return a-b