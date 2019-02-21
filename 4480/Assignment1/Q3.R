library("abind")
library("magic")
library("geometry")

# Cartesian to barycentric
X <- rbind(c(0, 10),
           c(0, 0),
           c(10, 0))
# Cartesian cooridinates of points
U <- readline(prompt = "Enter x: ")
U <- as.integer(U)
Y <- readline(prompt = "Enter y: ")
Y <- as.integer(Y)
u <- readline(prompt = "Enter x: ")
u <- as.integer(u)
y <- readline(prompt = "Enter y: ")
y <- as.integer(y)
P <- rbind(c(U, Y), c(u, y))
print("Barycentric coordinates: ")
cart2bary(X, P)


# Barycentric to cartesian
x <- rbind(c(0, 10),
           c(0, 0),
           c(10, 0))
# Cartesian cooridinates of points
U <- readline(prompt = "Enter u: ")
U <- as.integer(U)
V <- readline(prompt = "Enter v: ")
V <- as.integer(V)
W <- readline(prompt = "Enter w: ")
W <- as.integer(W)
u <- readline(prompt = "Enter u: ")
u <- as.integer(u)
v <- readline(prompt = "Enter v: ")
v <- as.integer(v)
w <- readline(prompt = "Enter w: ")
w <- as.integer(w)
B <- rbind(c(U, V, W), c(u, v, w))
print("Cartesian coordinates")
bary2cart(x, B)

