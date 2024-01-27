extends Node2D

const DUCK = preload("res://Scenes/entitise/goose.tscn")

func _input(event: InputEvent) -> void:
	if Input.is_action_just_pressed("select_left"):
		save_left_body()
		save_changed_duck()
	elif Input.is_action_just_pressed("select_right"):
		save_right_body()
		save_changed_duck()

func _ready() -> void:
	generate_right_background()
	generate_player_duck("right_background")

## 生成左边的背景蒙版
func generate_right_background() -> void:
	var right_background := Sprite2D.new()
	right_background.texture = preload("res://Scenes/entitise/mirror_folder/蒙版.png")
	right_background.position = Vector2(get_viewport_rect().end.x / 4, get_viewport_rect().end.y / 2)
	right_background.name = "right_background"
	add_child(right_background)

## 生成右边的背景蒙版
func generate_left_background() -> void:
	var left_background := Sprite2D.new()
	left_background.texture = preload("res://Scenes/entitise/mirror_folder/蒙版.png")
	left_background.position = Vector2(get_viewport_rect().end.x * 3 / 4, get_viewport_rect().end.y / 2)
	left_background.name = "left_background"
	add_child(left_background)

## 生成玩家控制的角色，background参数决定生成在哪个背景蒙版节点下
func generate_player_duck(background: String) -> void:
	var player_duck := DUCK.instantiate()
	player_duck.name = "player_duck"
	player_duck.rotation = 0.3
	get_node(background).add_child(player_duck)

## 生成镜像角色，background参数决定生成在哪个背景蒙版节点下
func generate_mirror_duck(background: String) -> void:
	var player_duck = get_node("right_background").get_child(0)
	change_owner(player_duck)
	var temp_player_duck_resource = PackedScene.new()
	temp_player_duck_resource.pack(player_duck)
	ResourceSaver.save(temp_player_duck_resource, "res://Scenes/entitise/mirror_folder/temp_player_duck_resource.tscn")
	
	var mirror_duck = load("res://Scenes/entitise/mirror_folder/temp_player_duck_resource.tscn").instantiate()
	mirror_duck.name = "mirror_duck"
	mirror_duck.scale.x = -1
	get_node(background).add_child(mirror_duck)

## 镜像位置
func mirror_position(mirror_duck: Node2D) -> void:
	var player_duck = get_node("right_background/player_duck")
	mirror_duck.global_position = Vector2(get_viewport_rect().end.x - player_duck.global_position.x ,player_duck.global_position.y)

## 镜像角度
func mirror_rotation(mirror_duck: Node2D) -> void:
	var player_duck = get_node("right_background/player_duck")
	mirror_duck.rotation = -player_duck.rotation

## 复制操作时保存左边部分
func save_right_body() -> void:
	# 将两个背景clip模式变成clip_only，并将镜像角色加入到右侧背景下
	get_node("right_background").clip_children = CanvasItem.CLIP_CHILDREN_ONLY
	generate_left_background()
	generate_mirror_duck("left_background")
	get_node("left_background").clip_children = CanvasItem.CLIP_CHILDREN_ONLY
	# 镜像操作
	var mirror_duck = get_node("left_background/mirror_duck")
	mirror_position(mirror_duck)
	mirror_rotation(mirror_duck)

## 复制操作时保存右边部分
func save_left_body() -> void:
	# 将两个背景clip模式变成clip_only，并将镜像角色加入到左侧背景下
	get_node("right_background").clip_children = CanvasItem.CLIP_CHILDREN_ONLY
	generate_left_background()
	generate_mirror_duck("right_background")
	get_node("left_background").clip_children = CanvasItem.CLIP_CHILDREN_ONLY
	# 镜像操作
	var mirror_duck = get_node("right_background/mirror_duck")
	mirror_position(mirror_duck)
	mirror_rotation(mirror_duck)
	
	reset_player_duck_body()

## 重设玩家控制的角色，删除默认在左侧的玩家角色，在右侧关于背景中心点对称位置生成对应节点
func reset_player_duck_body() -> void:
	var player_duck := DUCK.instantiate()
	player_duck.name = "player_duck"
	player_duck.position.y = get_node("right_background/player_duck").position.y
	player_duck.position.x = get_node("right_background/player_duck").position.x - get_node("left_background").texture.get_width()
	player_duck.rotation = get_node("right_background/player_duck").rotation
	get_node("left_background").add_child(player_duck)
	get_node("right_background/player_duck").free()

func change_owner(changeNode: Node) -> void:
	var childArray: Array = get_all_child(changeNode)
	for child in childArray:
		child.owner = changeNode

func get_all_child(fatherNode: Node) -> Array:
	var childArray: Array = []
	if fatherNode.get_child_count() == 0:
		return childArray
	for child in fatherNode.get_children():
		if child.get_child_count() > 0:
			childArray.append_array(get_all_child(child))
		childArray.append(child)
	return childArray

func save_changed_duck() -> void:
	save_changed_duck_to_file()
	get_node("right_background").free()
	get_node("left_background").free()
	call_deferred("add_new_player_duck")

func save_changed_duck_to_file() -> void:
	change_owner(get_node("right_background"))
	change_owner(get_node("left_background"))
	
	var right_bg_packed := PackedScene.new()
	right_bg_packed.pack(get_node("right_background"))
	ResourceSaver.save(right_bg_packed, "res://Scenes/entitise/mirror_folder/right_bg_packed.tscn")
	
	var left_bg_packed := PackedScene.new()
	left_bg_packed.pack(get_node("left_background"))
	ResourceSaver.save(left_bg_packed, "res://Scenes/entitise/mirror_folder/left_bg_packed.tscn")

func add_new_player_duck() -> void:
	var player_duck := Sprite2D.new()
	player_duck.name = "player_duck"
	player_duck.set_script(load("res://Scenes/entitise/goose.gd"))
	player_duck.position -= Vector2(
		get_viewport_rect().size.x / 4,
		get_viewport_rect().size.y / 2
	)
	
	var r1 = load("res://Scenes/entitise/mirror_folder/right_bg_packed.tscn").instantiate()
	r1.get_child(0).set_script(null)
	player_duck.add_child(r1)
	
	var r2 = load("res://Scenes/entitise/mirror_folder/left_bg_packed.tscn").instantiate()
	r2.get_child(0).set_script(null)
	player_duck.add_child(r2)
	
	generate_right_background()
	get_node("right_background").add_child(player_duck)
