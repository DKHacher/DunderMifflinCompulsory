#had some problems getting scaffold to work properly so i had to change the line and insert it manually into the terminal 

#!/bin/bash
dotnet ef dbcontext scaffold  "Server=localhost;Database=DunderMifflin;User Id=testuser;Password=testpass;"  Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models --context-dir . --context DmContext  --no-onconfiguring --data-annotations --force
