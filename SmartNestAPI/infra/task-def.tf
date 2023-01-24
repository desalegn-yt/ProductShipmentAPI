resource "aws_ecs_task_definition" "this" {
  family                   = "smartnest_api"
  memory                   = 512
  cpu                      = 256
  requires_compatibilities = ["FARGATE"]
  task_role_arn            = aws_iam_role.task.arn
  execution_role_arn       = aws_iam_role.task.arn
  network_mode             = "awsvpc"
  container_definitions = jsonencode(
    [{
      "name" : "smartnest-api"
      "image" : "443233915352.dkr.ecr.ap-southeast-2.amazonaws.com/smartnest_api",
      "portMappings" : [
        { containerPort = 80 }
      ],
    }]
  )
}