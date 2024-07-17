# Stage 1: Build the application
FROM node:20-alpine AS builder

# Install dependencies and Python for node-gyp
RUN apk add --no-cache python3 make g++


# Set the working directory
WORKDIR /app

# Install dependencies
COPY package*.json ./
RUN npm install -g npm@10.8.0 && npm install

# Copy the rest of the application files
COPY . .

# Build the application
RUN npm run build

# Stage 2: Serve the application using a lightweight web server
FROM node:20-alpine AS runner

# Create a non-root user to run the application
RUN addgroup -S nextjs && adduser -S nextjs -G nextjs

# Set the working directory
WORKDIR /app

# Copy the built application from the builder stage
COPY --from=builder /app ./

# Install only production dependencies
RUN npm install -g npm@10.8.0 && npm install --production


# Change ownership of the app directory
RUN chown -R nextjs:nextjs /app

# Switch to the non-root user
USER nextjs

# Expose the port the app runs on
EXPOSE 3000

# Set environment variables
ENV NODE_ENV production
ENV PORT 3000

# Start the Next.js application
CMD ["npm", "start"]

# Health check to ensure the container is running correctly
HEALTHCHECK --interval=1m --timeout=10s --start-period=10s --retries=3 \
    CMD curl -f http://localhost:3000/ || exit 1
