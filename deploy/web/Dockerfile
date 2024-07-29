FROM node:18.17.1-alpine AS production
WORKDIR /app
COPY /src/ShoppingCenter.Web .
RUN npm ci
RUN npm run build

FROM node:18.17.1-alpine AS development
WORKDIR /app
COPY /src/ShoppingCenter.Web .
RUN npm ci
CMD [ "npm", "run", "dev" ]
