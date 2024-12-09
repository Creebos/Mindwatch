# Use a lightweight Python image
FROM python:3.9-slim

# Set the working directory
WORKDIR /app

# Copy required files
COPY app.py .
COPY requirements.txt .
COPY models/ ./models/

# Install dependencies
RUN pip install --no-cache-dir -r requirements.txt

# Download NLTK data
RUN python -m nltk.downloader stopwords wordnet

# Expose the application port
EXPOSE 5174

# Run the application
CMD ["python", "app.py"]
