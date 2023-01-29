output "url" {
  value = aws_lb.this.dns_name
}
output "repository_url" {
  value = aws_ecr_repository.smartnest
}

