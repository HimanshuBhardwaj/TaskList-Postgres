
kubectl delete service tasklist-db-service --ignore-not-found=true
kubectl delete service tasks-app-svc --ignore-not-found=true
kubectl delete deployment tasks-app-deployment --ignore-not-found=true
kubectl delete deployment tasklist-db-deployment --ignore-not-found=true
kubectl delete ReplicaSet tasks-app-rs --ignore-not-found=true
kubectl delete pod tasks-app --ignore-not-found=true
kubectl delete pvc,pv --all --ignore-not-found=true
clear