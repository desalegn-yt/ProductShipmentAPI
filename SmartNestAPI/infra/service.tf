resource "aws_ecs_service" "api_service" {
	name = "smartNestService-service"
	cluster = aws_ecs_cluster.this.id
	task_definition = aws_ecs_task_definition.this.arn
	launch_type  = "FARGATE"
	deployment_maximum_percent = 200
	deployment_minimum_healthy_percent = 100
	desired_count = 1
	network_configuration {
		assign_public_ip = true
		subnets = data.aws_subnet_ids.this.ids
		security_groups = [aws_security_group.this.id]
	}
}