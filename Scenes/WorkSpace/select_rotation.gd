extends CanvasLayer

var selected: bool = false
var selected_limb: Node2D
@onready var v_scroll_bar: VScrollBar = $VScrollBar

func _ready() -> void:
	v_scroll_bar.value = 50
	
func _process(delta: float) -> void:
	if selected:
		caculate()
	
func caculate() -> void:
	var rot: float = (v_scroll_bar.value - 50) / 50 * PI
	selected_limb.rotation = rot

func _input(event: InputEvent) -> void:
	if selected:
		return
	
	if event is InputEventMouseButton:
		if event.button_index == 1:
			if event.is_pressed():
				for limb in $Goose.get_children():
					if limb.mouse_in_area:
						selected = true
						limb.selected = true
						selected_limb = limb
						limb.modulate = Color(1,0,0)
