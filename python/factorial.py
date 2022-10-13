def factorial(n):
    result=1
    if n==0:
        return result
    else:
        while n>0:
            result*=n
            n=n-1
    return result
