pipeline {
  agent {
    node {
      label 'linux'
    }

  }
  stages {
    stage('docker build') {
      steps {
        echo 'echo docker build'
        sh '''echo $WORKSPACE
docker run --rm -v /home/jenkins/workspace/lr_efcore_test_jenkins_blueocean:/app mcr.microsoft.com/dotnet/core/sdk:2.2 dotnet publish /app/asp_efcore.sln -o /app/bin
docker run --rm -v /home/jenkins/workspace/lr_efcore_test_jenkins_blueocean:/app mcr.microsoft.com/dotnet/core/sdk:2.2 chmod -R 777 /app/bin'''
      }
    }
    stage('test') {
      steps {
        sh '''echo "run server"  
docker run --rm -v /home/jenkins/workspace/lr_efcore_test_jenkins_blueocean:/app mcr.microsoft.com/dotnet/core/aspnet:2.2 dotnet /app/bin/asp_signalR_efcore.dll &'''
        sleep 3
        sh '''echo "run client" 
docker run --rm -v /home/jenkins/workspace/lr_efcore_test_jenkins_blueocean:/app mcr.microsoft.com/dotnet/core/aspnet:2.2 dotnet /app/bin/signalR_client.dll  &'''
        input 'check running result'
      }
    }
    stage('deploy') {
      steps {
        archiveArtifacts(artifacts: '/home/jenkins/workspace/lr_efcore_test_jenkins_blueocean/bin/', onlyIfSuccessful: true)
        echo 'echo "deploy"'
      }
    }
  }
}