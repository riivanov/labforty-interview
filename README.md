Given the timeframe, this README is incomplete, no testing has been done (especially on Windows).
I assume you have postgres installed and configured.

If you'd like to see my attempt at AUTH: `git checkout main`

```
git clone https://github.com/riivanov/labforty-interview.git
cd labforty-interview
git checkout v0.0.1
```

- `cd API`
- `dotnet restore`
- install postgres
- configure postgres
  - `sudo -u postgres initdb -D /var/lib/postgres/data` # initialize the DB
  - `sudo -u postgres createuser -P -S -R -d username` # use `password` as password
- install ef tools
  - `dotnet tool install --global dotnet-ef`
- run migrations (to create initial DB)
  - `dotnet ef database update`
- run project
  - `dotnet watch run`

This is a project that I'm ashamed of, I was considering not even posting it. It's incomplete, and I don't like turning in incomplete work. Had I been given a sprint(2 weeks), it would be much nicer and most of all would work.

I used these `curl` commands to test the API, however, they probably will NOT work:

```
CREATE: curl -s --insecure --json @post.json -X POST https://localhost:5114/api/Customers
READ:   curl -s --insecure -X GET https://localhost:5114/api/Customers

# In `post.json` orders->product->id will have to be manually incremented
UPDATE: curl -s --json @post.json --insecure -X PUT https://localhost:7123/api/Customers/6
DELETE: curl -s --insecure -X DELETE https://localhost:7123/api/Customers/1
```
