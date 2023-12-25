Given the timeframe, this README is incomplete, no testing has been done (especially on Windows).
I assume you have postgres installed

```
cd labforty-interview
git clone https://github.com/riivanov/labforty-interview.git
git checkout v0.0.1
```

- `cd API`
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
