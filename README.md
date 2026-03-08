# vrt-observability-integration-project-2

![Architectuur](docs/architecture.png)

## Setup

```bash
git clone <repo-url>
cd VrtAws/app
docker compose up -d
```

## UI Access

| Service    | URL                                  |
|------------|--------------------------------------|
| Vote       | http://<public-ip>:5000              |
| Result     | http://<public-ip>:5001              |
| Prometheus | http://<public-ip>:9090              |
| Grafana    | http://<public-ip>:3000  (admin/admin) |
| Loki       | http://<public-ip>:3100              |