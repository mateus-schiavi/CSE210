import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D

fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')

# Walls
ax.plot([0,0,1,1,0],[0,1,1,0,0],[0,0,0,0,0], color='gray')
ax.plot([0,0,1,1,0],[0,1,1,0,0],[1,1,1,1,1], color='gray')
ax.plot([0,1,1],[0,0,0],[0,0,1], color='gray')
ax.plot([0,1,1],[1,1,1],[0,0,1], color='gray')

# Roof
ax.plot([0,0.5,1,0],[0,1,0.5,1],[1,1.5,1,1], color='red')

ax.set_xlim(0,1)
ax.set_ylim(0,1)
ax.set_zlim(0,1.5)

plt.show()
