# Stage 1: Build
FROM node:18 AS build

WORKDIR /app
COPY package*.json ./
RUN npm install --force

EXPOSE 5173

CMD ["npm", "run", "dev", "--host"]