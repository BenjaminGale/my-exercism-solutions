
# Queen Attack

## Overview

Solving this problem involves understanding how the queen piece can move and attack. The queen can be moved:

 - Any number of unoccupied squares in a straight line **horizontally**.
 - Any number of unoccupied squares in a straight line **vertically**.
 - Any number of unoccupied squares in a straight line **diagonally**.

If the target queen falls on any of these squares then it can be attacked.

### Horizontal & Vertical attacks

Solving these cases is straightforward.

 - If the target queen occupies the same **row** as your queen then it can be attacked **horizontally**.
 - If the target queen occupies the same **column** as your queen the it can be attacked **vertically**.

### Diagonal attacks

The key insight to determining if another queen can be attacked diagonally is to understand how diagonal movement affects the **row** and **column** the piece occupies.

When the piece is moved **one** square diagonally then both the **row** and **column** change by one e.g. If your queen occupies square (3, 5) then moving diagonally up and to the right means your queen now occupies square (4, 6).

Moving the piece up and diagonally **three** squares changes both the **row** and **column** by **three** i.e. (1, 2) becomes (4, 5).

Expressed another way, if the **difference** between both the **row** and **column** of both pieces is the same then the pieces must occupy the same diagonal (so can attack each other).

Care needs to be taken when the piece makes a diagonal move that produces values that are not the same e.g.

 - Move (4, 5) down and to the right by one square = (3, 6)
 - The difference between these squares is (3 - 4 = **-1**, 6 - 5 = **1**)

Each piece has moved by the same **amount** but the **direction** is different. To solve this we can take the absolute values of the differences between the rows and columns as we are only interested **amount** moved.
