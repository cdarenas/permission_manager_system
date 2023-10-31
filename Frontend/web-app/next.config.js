/** @type {import('next').NextConfig} */
const nextConfig = {
  env: {
    PATH_URL_CMD_API: "http://localhost:5010",
    PATH_URL_QUERY_API: "http://localhost:5011",
  },
  output: "export",
};

module.exports = nextConfig;
